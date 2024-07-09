$(document).ready(function () {
    $("form").each(function () {
        $(this).validate({
            errorClass: 'text-danger',
            rules: {
                Username: {
                    required: true,
                    minlength: 3
                },
                Password: {
                    required: true,
                    minlength: 6
                },
                ConfirmPassword: {
                    required: true,
                    minlength: 6,
                    equalTo: "#Password"
                },
                UserType: {
                    required: true
                }
            },
            messages: {
                Username: {
                    required: "نام کاربری ضروری است",
                    minlength: "نام کاربری باید حداقل ۳ حرف باشد"
                },
                Password: {
                    required: "رمز عبور ضروری است",
                    minlength: "رمز عبور باید حداقل ۶ حرف باشد"
                },
                ConfirmPassword: {
                    required: "تکرار رمز عبور ضروری است",
                    minlength: "رمز عبور باید حداقل ۶ حرف باشد",
                    equalTo: "رمز عبور و تکرار آن مطابقت ندارند"
                },
                UserType: {
                    required: "نوع کاربری ضروری است"
                }
            }
        });
    });
});
