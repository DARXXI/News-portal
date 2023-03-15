var AdminPanel = {
    Init: function(test) {

    },
    Utils:
    {
        dateFormatter: function(date, format = 'L') {
            moment.locale("ru");
            return moment(date).format(format) + " " + moment(date).format('LT');
        }
    },
    Validation:
    {
        login: function() {
            $(document).ready(function() {
                $("#editForm").validate({
                    rules: {
                        Email: {
                            required: true,
                            minlength: 1,
                            email: true,
                            maxlength: 100
                        },
                        Password: {
                            required: true,
                            minlength: 6,
                            maxlength: 36
                        }
                    }
                });
            });
        }


    }
};  


//let form = document.getElementById("imageUploading");
//window.onsubmit = function () {
//    debugger;
//    imageLinks();
//}

//function imageLinks() {
//    var anchors = document.querySelectorAll('img');
//    Array.prototype.forEach.call(anchors, function (array) {
//        array.classList.add('img-link');
//    });
//    debugger;
//}

