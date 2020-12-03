function loadComments(id, url) { 

    isLoading(true);
    var commentTemplate = '<div class="answer">' +
        '<img class="img-comments" alt="" src="images/faces/100x100/rdeovte7vos-christopher-campbell.jpg" >' +
        '<div class="content-cmt">' +
        '<span class="name-cmt">--creatorName--</span>' +
        '<span class="date-cmt">--creationDateTime--</span>' +
        '<p class="content-reply">--content--' +
        '</p>' +
        '</div>' +
        '</div >';
    if (url == null) {
        url = "\\AdminPanel\\comment\\getComments";
    }
    var element = $("#" + id);
    isLoadingInContainer(true, id);
    var itemId = element.attr("idItem");
    var itemTypeId = element.attr("itemTypeId");
    var secondParam = element.attr("secondParam");
    var mainUrl = url + "/" + itemId + "/" + secondParam ;
    $.post(mainUrl,
        { commentOwnerType: itemTypeId}).
        then(function (data) {
            $(".messagesContainer", $("#" + id)).html("");
            for (var i in data) {
                var element = data[i];
                var tempTemplate = commentTemplate;
                tempTemplate = tempTemplate.replace('--creatorName--', element.ownerUserName);
                tempTemplate = tempTemplate.replace('--creationDateTime--', element.persiandateInserted);
                tempTemplate = tempTemplate.replace('--content--', element.commentText);
                $(".messagesContainer", $("#" + id)).append(tempTemplate);
            }   
        }).
        fail(function () { }).
        always(function () {
            isLoadingInContainer(false, id);
        });


} 
function login(sender, userName, password, ResultContainer) { 

    isLoading(true);
    var objectForSend = new Object();
    objectForSend.userName = userName;
    objectForSend.passWord = password;
    $.post(document.location.origin + "/AdminPanel/Auth/loginP", objectForSend)
        .done(function (data) {
            if (data == "true") {
                window.location.reload()
            } else {
                if (ResultContainer) {
                    $(idResultContainer).html("ورود موفقیت آمیز نبود...");
                } else
                alert("ورود موفقیت آمیز نبود...");
            }

            isLoading(false);
        })
}
function SubmitNewVote(sender, voteValue, onSuccess, onFail) {
    isLoading(true);
    var containre = $(sender).closest('.voteContainr');
    var url = $(containre).attr("fillUrl");
    var submitUrl = url + "&newVoteValue=" + voteValue;
    $.get(submitUrl)
        .done(function (data) {
            if (onSuccess) {
                onSuccess(data);
            }
            $(containre).html(data);
        })
        .fail(function () {
            if (onFail) {
                onFail();
            }
        })
        .always(function () {
            isLoading(false);
        });
}
function fillWithUrlResult(divId, onSuccess, onFail, ) { 
    var item = $("#" + divId);
    var url = $(item).attr("fillUrl"); 
    $.get(url)
        .done(function (data) { 
            if (onSuccess) {
                onSuccess(data);
            }
            $("#" + divId).html(data);
        })
        .fail(function () {
            if (onFail) {
                onFail();
            }
        })
        .always(function () {
            isLoading(false);
        });
}
function submitNewComment(sender) { 
    var elementContainer = $(sender).closest(".commentsContainer");
    var containerId = elementContainer.attr("id");
    isLoadingInContainer(true, containerId);
    var itemId = elementContainer.attr("idItem");
    var itemTypeId = elementContainer.attr("itemTypeId");
    var secondParam = elementContainer.attr("secondParam");
    var commentText = $(".messagetextContaner", $(elementContainer)).val();
    var dataForSendingToServer = new Object();
    dataForSendingToServer.commentText = commentText;
    dataForSendingToServer.ownerID = itemId; 
    dataForSendingToServer.partParam = itemTypeId;
    dataForSendingToServer.secondPartParam = secondParam;
    var basePath = "\\AdminPanel\\comment";
    var urlForSendingData = basePath+"\\addComment";
    $.post(urlForSendingData,
        dataForSendingToServer).then(function (data) {
            debugger;
            loadComments(containerId, basePath + "\\getComments");
        }).
        fail(function () { }).
        always(function () {
            isLoadingInContainer(false, containerId);
        });
}

let urlParams = {};
(window.onpopstate = function () {
    let match,
        pl = /\+/g,  // Regex for replacing addition symbol with a space
        search = /([^&=]+)=?([^&]*)/g,
        decode = function (s) {
            return decodeURIComponent(s.replace(pl, " "));
        },
        query = window.location.search.substring(1);

    while (match = search.exec(query)) {
        if (decode(match[1]) in urlParams) {
            if (!Array.isArray(urlParams[decode(match[1])])) {
                urlParams[decode(match[1])] = [urlParams[decode(match[1])]];
            }
            urlParams[decode(match[1])].push(decode(match[2]));
        } else {
            urlParams[decode(match[1])] = decode(match[2]);
        }
    }
})();
function addTabToMainWindowsFreamWork(item) {
    var tabTitle = $(item).attr("tabTitle");
    var tabUrl = $(item).attr("tabUrl");
    tabUrl = tabUrl + "?v=" + Math.random();
    var content = '<iframe scrolling="auto" frameborder="0"  src="' + tabUrl + '" style="width:100%;height:100%;"></iframe>';
    $('#mainTabContainer').tabs('add', {
        title: tabTitle,
        content: content,
        closable: true
    });
}
function sendFileToServer(url, data, onSuccess, onFail,finnaly) {
    isLoading(true);
    $.ajax({
        url: url,
        type: 'POST',
        data: data, // The form with the file inputs.
        processData: false,
        contentType: false                    // Using FormData, no need to process data.
    }).done(function (data) {
        if (onSuccess) {
            onSuccess(data);
        } 
    }).fail(function () {
        if (onFail) {
            onFail();
        }
    }).always(function () {
        if (finnaly) {
            finnaly();
        }
        isLoading(false);
    });
}
function setContent(url, destinationID, onSuccess, onFail) { 
    let destinationId = destinationID;
    isLoading(true);
    $.get(url)
        .done(function (data) {
            if (onSuccess) {
                onSuccess(data);
            }
            $("#" + destinationID).html(data);
        })
        .fail(function () {
            if (onFail) {
                onFail();
            }
        })
        .always(function () {
            isLoading(false);
        });

}
function showMessageToUse() {
    alert("function Successeeded!!!");
} 
function testFunc() {
    getMostParentWindow().testIsLoading();
}
function getMostParentWindow() {
    var mostParentWindow = window;
    while (!(mostParentWindow.mostParentWindow)) { 
        mostParentWindow = mostParentWindow.parent;
    }
    return mostParentWindow;
}
function testIsLoading() {
    isLoading(true);
    setTimeout(function () {
        isLoading(false);
    },3000)
}
function postForm2(sender) { 
    var senderForm = $(sender).closest("form");
    var postUrl = $(senderForm).attr("actionUrl");
    var parent = $(senderForm).parent(".formParent"); 
    senderForm.submit();
}
function getData(url, onSuccess, onFail) { 
    isLoading(true);
    $.get(url)
        .done(function (data) { 
            if (onSuccess) {
                onSuccess(data);
            }
        })
        .fail(function () {
            if (onFail) {
                onFail();
            }
        })
        .always(function () {
            isLoading(false);
        });

}
function postData(url, data, successFunc, failedFunc, alwaysFunc) {
    isLoading(true);
    var postUrl = url; 
    let jsonObject = data;
    getMostParentWindow().isLoading(true);
    $.post(postUrl, jsonObject)
        .done(function (data) {
            if (successFunc) {
                successFunc(data);
            } 
        })
        .fail(function (err) {
            if (failedFunc) {
                failedFunc(err);
            }
        })
        .always(function () {
             
            if (alwaysFunc) {
                alwaysFunc();
            }
            isLoading(false);
        });
}
function getOBjectsOfData(formObject) {
    let jsonObject = Array.from(formObject.get(0).querySelectorAll('input, select, textarea'))
        .filter(element => element.name)
        .reduce((json, element) => {
            json[element.name] = element.type === 'checkbox' ? element.checked : element.value;
            return json;
        }, {});
    return jsonObject;
}
function validateFormObject(formObject) {
    var result = true;
    let elementArray = Array.from(formObject.get(0).querySelectorAll('input, select, textarea'))
        .filter(element => element.name);
    for (var i = 0; i < elementArray.length; i++) {
        $(elementArray[i]).removeClass("inputHasError"); 
    }
    for (var i = 0; i < elementArray.length; i++) {
        if ($(elementArray[i]).attr('required')) {
            if ($(elementArray[i]).val().length < 1) {
                $(elementArray[i]).addClass("inputHasError");
                result = false;
            }  
        }
        if ($(elementArray[i]).attr('pattern')) {
            var patern = $(elementArray[i]).attr('pattern');
            if (patern && patern.length > 0) {
                var elementVal = $(elementArray[i]).val();
                var reg = RegExp(patern);
                if (reg.test(elementVal) == false) {
                    $(elementArray[i]).addClass("inputHasError");
                    result = false; 
                }  
            }
        }
    }
    return result;
}
function postFormWithOptimizer(sender, optimiser, successFunc, failedFunc, alwaysFunc) {
    isLoading(true);
    var senderForm = $(sender).closest("form");
    var postUrl = $(senderForm).attr("actionUrl");
    var parent = $(senderForm).parent(".formParent");
    let jsonObject = Array.from(senderForm.get(0).querySelectorAll('input, select, textarea'))
        .filter(element => element.name)
        .reduce((json, element) => {
            json[element.name] = element.type === 'checkbox' ? element.checked : element.value;
            return json;
        }, {});
    if (optimiser) {
        optimiser(data);
    }
    isLoading(true);
    $.post(postUrl, jsonObject)
        .done(function (data) {
            if (successFunc) {
                successFunc(data);
            }
            $(parent).html(data);
        })
        .fail(function (err) {
            if (failedFunc) {
                failedFunc(err);
            }
        })
        .always(function () {

            if (alwaysFunc) {
                alwaysFunc();
            }
            isLoading(false);
        });

}
function postForm(sender, successFunc, failedFunc, alwaysFunc) { 
    var senderForm = $(sender).closest("form");
    var postUrl = $(senderForm).attr("actionUrl");
    var parent = $(senderForm).parent(".formParent");
    let jsonObject = Array.from(senderForm.get(0).querySelectorAll('input, select, textarea'))
        .filter(element => element.name)
        .reduce((json, element) => {
            json[element.name] = element.type === 'checkbox' ? element.checked : element.value;
            return json;
        }, {});
    isLoading(true);
    $.post(postUrl, jsonObject)
        .done(function (data) {
            if (successFunc) {
                successFunc(data);
            }
            $(parent).html(data); 
        })
        .fail(function (err) {
            if (failedFunc) {
                failedFunc(err);
            }
        })
        .always(function () {

            if (alwaysFunc) {
                alwaysFunc();
            }
            isLoading(false);
    });
}
function getDataFromServer() {

}
function isLoading(showLoading) {
    if (showLoading) {
        $(".loading").show();
    } else {
        $(".loading").hide();
    }
}
function isLoadingInContainer(showLoading,containerID) {
    if (showLoading) {
        $(".loaderInternal", $("#" + containerID)).show();
    } else {
        $(".loaderInternal", $("#" + containerID)).hide(); 
    }
}
