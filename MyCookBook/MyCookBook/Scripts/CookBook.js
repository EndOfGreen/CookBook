function ImageFilePost(input, url, output) {
    var formData = new FormData();
    var file = document.getElementById(input).files[0];
    formData.append(input, file);
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {
            $(".thumb").remove();
            $('#' + output).html(['<img class="thumb" src="', data, '"/>'].join(''));
            viewModel.ImageLink = data;
        }
    });
};


function Back()
{ history.back(); };

function Redirect(url) {
    window.location.href = url;
};