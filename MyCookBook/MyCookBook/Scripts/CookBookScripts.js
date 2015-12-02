function ImageFileUpload(input, controller, output) {
    var formData = new FormData();
    var file = document.getElementById(input).files[0];
    formData.append(input, file);
    $.ajax({
        url: controller,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {
            $('#' + output).html(['<img class="thumb" src="', data, '"/>'].join(''));
            this.Model.ImageLink = data;
        }
    });
};