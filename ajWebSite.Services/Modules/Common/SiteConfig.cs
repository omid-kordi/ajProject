using ajWebSite.Services.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ajWebSite.Core.Module
{
    public class SiteConfig
    {
        public string AdminEmailAddress { get; set; }

        public string siteName { get; set; }
    }
    public class currentConfig
    {
        IConfigBiz _configBiz;
        public SiteConfig configs { get; set; }
        private object lockConfig = new object();
        public currentConfig(IConfigBiz configBiz)
        {
            _configBiz = configBiz;
            reloadConfig();
        }
        public void reloadConfig()
        { 
            lock (lockConfig)
            {
                if (configs != null)
                {

                }
                else
                {
                    configs = new SiteConfig();
                    var tconfigs = _configBiz.GetAll();
                    foreach (var item in typeof(SiteConfig).GetProperties())
                    {
                        var configValue = tconfigs.FirstOrDefault(p => p.configName == item.Name);
                        if (configValue != null)
                        {
                            item.SetValue(configs, configValue.configValue);
                        }
                    }
                }
            }
        }
        public void saveConfigs()
        { 
            var configsSaved = _configBiz.GetAll();
            foreach (var item in typeof(SiteConfig).GetProperties())
            {
                var tempProperty = configsSaved.FirstOrDefault(p => p.configName == item.Name);
                if (tempProperty==null)
                {
                    tempProperty = new Common.DTOs.Common.configDTO();
                }
                tempProperty.configName = item.Name;
                tempProperty.configValue = (item.GetValue(configs)??"").ToString();
                if (tempProperty.Id>0)
                {
                    _configBiz.Update(tempProperty);
                }
                else
                {
                    _configBiz.InsertAndReturn(tempProperty);
                }
            }
            configs = null;
            reloadConfig();
        }
    }
}
