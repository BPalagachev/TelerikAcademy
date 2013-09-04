/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

(function () {
    var getPost = function(author, content) {
        var newPost = {
            Author: author,
            Content: content
        }

        return newPost;
    }

    var posts = new WinJS.Binding.List([]);

    WinJS.Namespace.define("Data", {
        postsList: posts,
        getPost: getPost
    });
    
}())