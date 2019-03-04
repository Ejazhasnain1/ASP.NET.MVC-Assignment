var cloneCount = 1;
$(document).ready(function () {

    
    $("#addContactField").click(function () {
        $("#cloneItem").clone().append('<div><input type="text" class="fields-value" id="ContactNumber' + cloneCount + '" placeholder="Enter your Number" required="true" name="ContactNumber" oninput="validate.isContactValid(cloneCount)"</input><div class="error" id="errorContactInfo'+ cloneCount + '"></div></div>').insertBefore("#addItem");
        cloneCount++;
    });


    $(".email-check").keyup(function () {
        var email = $(".email-check").val();
        $.ajax({
            type: "POST",
            url: "UsernameAvailablity",
            data: '{userEmail:"' + email + '"}',
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            success: function (result) {
                var message = $("#emailAvailabilty");
                if (result) {
                    if ($(".email-check").val() === "") {
                        message.html("");
                    }
                    else {
                        message.html("*Email ID is available.");
                        message.css("color", "green");
                    }
                }
                else {
                    message.html("*This Email ID is already in Use");
                    message.css("color", "#e87e03");
                }
            }

        });
    });
 


    $('input[type=file]').change(function () {
        var val = $(this).val().toLowerCase(), regex = new RegExp("(.*?)\.(jpg|jpeg|png)$");
        if (!(regex.test(val)) || this.files[0].size >= 512000) {
            $(this).val('');
           $("#errorFile").html("*Uploaded file should be of Image type and size should be below 500kb");
        }
    });

   /* $('[id^=ContactNumber]').each(function (e) {
        $(this).rules('add', {
            maxlength: 12,
            number: true,
        });
    });*/

});