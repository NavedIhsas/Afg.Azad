var SinglePage = {};

SinglePage.LoadModal = function () {
   
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function (htmlPage) {
           
            var rr = $("#ModalContent");
            rr.html(htmlPage);
            $("#ModalContent").html(htmlPage);
            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            showModal();
        }).fail(function (error) {
            alert("خطایی رخ داده، لطفا با مدیر سیستم تماس بگیرید.");
        });
};

function showModal() {
   
    $("#MainModal").modal("show");
}

function hideModal() {
    $("#MainModal").modal("hide");
}

$(document).ready(function () {
    window.onhashchange = function () {
        SinglePage.LoadModal();
    };
    $("#MainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";

            $('.PersianDateInput').persianDatepicker({
                autoClose: true,
                format: 'YYYY/MM/DD',
            });

        });
    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
           
            e.preventDefault();
            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");

            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function (data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
               
                var formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    beforeSend: showLoader(),
                    success: function (data) {
                        CallBackHandler(data, action, form);
                    },
                    error: function (data) {
                       
                        notify("top-center", "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.", "error");
                    },
                    complete: function () {
                        $('#loader-single').addClass('hidden')
                    },
                });
            }
            return false;
        });
});

function showLoader() {
   
    var elem = document.getElementById('loader-single');
    elem.classList.remove('hidden'); // Remove class
 
}
function CallBackHandler(data, action, form) {
   
    switch (action) {
        case "Message":
            notify("top-center", data.Message, "error");
            break;
        case "Refresh":
            if (data.isSucceeded) {
                window.location.reload();
            } else {
                notify("top-center", data.message, "error");
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}

function get(url, refereshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function (result) {
            $("#" + refereshDiv).html(result);
        });
}

function makeSlug(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(convertToSlug(value));
}

var convertToSlug = function (str) {
    var $slug = '';
    const trimmed = $.trim(str);
    $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
    return $slug.toLowerCase();
};

function checkSlugDuplication(url, dist) {
    const slug = $('#' + dist).val();
    const id = convertToSlug(slug);
    $.get({
        url: url + '/' + id,
        success: function (data) {
            if (data) {
                sendNotification('error', 'top right', "خطا", "اسلاگ نمی تواند تکراری باشد");
            }
        }
    });
}

function fillField(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(value);
}

$(document).on("click",
    'button[data-ajax="true"]',
    function () {
        const button = $(this);
        const form = button.data("request-form");
        const data = $(`#${form}`).serialize();
        let url = button.data("request-url");
        const method = button.data("request-method");
        const field = button.data("request-field-id");
        if (field !== undefined) {
            const fieldValue = $(`#${field}`).val();
            url = url + "/" + fieldValue;
        }
        if (button.data("request-confirm") == true) {
            if (confirm("آیا از انجام این عملیات اطمینان دارید؟")) {
                handleAjaxCall(method, url, data);
            }
        } else {
            handleAjaxCall(method, url, data);
        }
    });



//position: top left, top right, middle,bottom,top,center,right,top right, 
//type: success,warn ,error,info
https://notifyjs.jpillora.com/

function notify(position, text, type) {
    $.notify(text, {
        className: type,
        clickToHide: true,
        autoHide: true,
        globalPosition: position
    });
}


$(document).ready(function () {
    $('#datatable').dataTable();
    $('#dataTables').dataTable();
});

function validateImage(input, width, hieght, buttonId = "") {
   

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = (function (theFile) {
           
            var image = new Image();
            image.src = theFile.target.result;
            image.onload = function (e) {
               
                $('#imgCourse').attr('src', e.target.result);

                if (this.width === width && this.height === hieght) {
                    {
                        notify("top center", "عکس تایید شد", "success")
                        if (buttonId != "") {
                            $("#" + buttonId).prop('disabled', false);
                        }

                    }
                } else {
                    notify("top center", "سایز عکس معتبر نیست", "error");
                    if (buttonId != "") {
                        $("#" + buttonId).prop('disabled', true);
                    }


                }
            };
        });
        reader.readAsDataURL(input.files[0]);
    }


}
function validateCourseGroupImg(input, width, hieght, buttonId = "") {
   

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = (function (theFile) {
           
            var image = new Image();
            image.src = theFile.target.result;
            image.onload = function (e) {
               
                $('#imgCourse').attr('src', e.target.result);

                if ((this.width === width && this.height === hieght)) {
                    {
                        notify("top center", "عکس تایید شد", "success")
                        if (buttonId != "") {
                            $("#" + buttonId).prop('disabled', false);
                        }

                    }
                } else {
                    notify("top center", "سایز عکس معتبر نیست", "error");
                    if (buttonId != "") {
                        $("#" + buttonId).prop('disabled', true);
                    }


                }
            };
        });
        reader.readAsDataURL(input.files[0]);
    }


}


function loadImg(id = "") {
   
    if (id = "")
        $('#imgCourse').attr('src', URL.createObjectURL(event.target.files[0]));
    else
        $('#' + id).attr('src', URL.createObjectURL(event.target.files[0]));
}

function handleAjaxCall(method, url, data) {
    if (method === "post") {
        $.post(url,
            data,
            "application/json; charset=utf-8",
            "json",
            function (data) {

            }).fail(function (error) {
                notify("top-center", "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.", "error");
            });
    }
}

jQuery.validator.addMethod("maxFileSize",
    function (value, element, params) {
        var size = element.files[0].size;
        var maxSize = 3 * 1024 * 1024;
        if (size > maxSize)
            return false;
        else {
            return true;
        }
    });
jQuery.validator.unobtrusive.adapters.addBool("maxFileSize");

//jQuery.validator.addMethod("maxFileSize",
//    function (value, element, params) {
//        var size = element.files[0].size;
//        var maxSize = 3 * 1024 * 1024;
//       ;
//        if (size > maxSize)
//            return false;
//        else {
//            return true;
//        }
//    });
//jQuery.validator.unobtrusive.adapters.addBool("maxFileSize");

