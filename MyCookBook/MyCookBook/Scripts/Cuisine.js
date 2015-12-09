function Save(url) {
    $.ajax({
        url: url,
        type: "POST",
        dataType: 'JSON',
        data: { '' : ko.mapping.toJSON(cuisineViewModel)},
        success: function (success)
        {
            if (success) alert('Успешно сохранено!');
            else alert('Не сохранено!');
        }
    })
};

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
            cuisineViewModel.ImageLink = data;
        }
    });
};