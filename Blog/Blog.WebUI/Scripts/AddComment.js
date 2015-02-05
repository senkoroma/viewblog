$(function () {
   var addComment = function () {
       var $commentTxt = $("#comment-txt");
       var $articleIdTxt = $("#article-id");
       var $commentUserTxt = $("#current-user");

       var comment = {
           ArticleId: $articleIdTxt.val(),
           Text: $commentTxt.val(),
           AuthorLogin: $commentUserTxt.val(),
           AuthorId: null,
           AuthorName: null
       };
       
       $.ajax({
           url: '/article/index',
           dataType: "json",
           type: "POST",
           
           data: comment,
           async: true,
           success: function(data) {
               displayNewComment(data);
           },
           error: function(xhr) {
               alert('error');
           }
       });
    }

    var displayNewComment = function(data) {
        var comment = {
            Text: data.Text,
            PostDate: new Date(parseInt(data.PostDate.substr(6))).toLocaleDateString("en-US") + " " + new Date(parseInt(data.PostDate.substr(6))).toLocaleTimeString("en-US"),
            AuthorName: data.AuthorName
        };

        $("#comments-list").append("<blockquote> <p>" + comment.Text + "</p> <p align=\"right\">" + comment.AuthorName +"  "+ comment.PostDate + " </p> </blockquote>");

        $("#comment-txt").val("");
    };

    var $addButton = $("#comment-btn");
    $addButton.on("click", function () {
        addComment();
    });
});



//(function ($) {
//    var articlePage = (function() {

//        var _private = {};
//        var _public = {};

//        _private.aButton_Click = new function() {
//            var $commentTxt = $("#comment-txt");
//            var $articleIdTxt = $("#article-id");
//            var $commentUserTxt = $("#current-user");

//            var comment = {
//                ArticleId: $articleIdTxt.val(),
//                Text: $commentTxt.val(),
//                AuthorLogin: $commentUserTxt.val(),
//                AuthorId: null,
//                AuthorName: null
//            };

//            $.ajax({
//                url: '/article/index',
//                dataType: "json",
//                type: "POST",

//                data: comment,
//                async: true,
//                success: function (data) {
//                    displayNewComment(data);
//                },
//                error: function (xhr) {
//                    alert('error');
//                }
//            });
//        };

//        var displayNewComment = function (data) {
//            var comment = {
//                Text: data.Text,
//                PostDate: new Date(parseInt(data.PostDate.substr(6))).toLocaleDateString("en-US") + " " + new Date(parseInt(data.PostDate.substr(6))).toLocaleTimeString("en-US"),
//                AuthorName: data.AuthorName
//            };

//            $("#comments-list").append("<blockquote> <p>" + comment.Text + "</p> <p align=\"right\">" + comment.AuthorName + "  " + comment.PostDate + " </p> </blockquote>");

//            $("#comment-txt").val("");
//        };

//        _public.init = function() {
//            console.log("article module init");
//            $("##comment-btn").on("click", _private.aButton_Click);
//        };

//        return _public;
//    })();

//    $(function() {
//        articlePage.init();
//    });     
//})(jQuery)