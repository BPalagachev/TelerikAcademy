// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll().then(function () {
                getPostsAsync();

                setInterval(function(){
                    getPostsAsync()
                }, 30000)

                var btnPost = document.getElementById("btn-post-content");
                btnPost.addEventListener("click", function () {
                    var author = document.getElementById("input-author-name").value;
                    var content = document.getElementById("txtarea-content").value;

                    var post = Data.getPost(author, content);
                    var info = document.getElementById("info");
                    info.innerText = "Posting... Please wait";
                    info.style.display = "";
                    btnPost.disabled = true;

                    HttpRequests.httpRequester.postJson("http://posted.apphb.com/api/posts", post).then(function () {
                        btnPost.disabled = false;
                        info.innerText = "Posted";
                        getPostsAsync();
                    }, function () {
                    });

                });
            }));
        }

        function getPostsAsync() {
            return HttpRequests.httpRequester.getJson("http://posted.apphb.com/api/posts")
                    .then(function (request) {
                        while (Data.postsList.length > 0) {
                            Data.postsList.pop();
                        }

                        var posts = JSON.parse(request.responseText);
                        for (var i = 0; i < posts.length; i++) {
                            Data.postsList.push(posts[i]);
                        }
                    })
        }

    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();
})();
