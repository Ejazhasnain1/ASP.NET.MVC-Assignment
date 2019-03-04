var validate =
    {        
        isNameValid: function (id, errorId) {
            var value = getId(id).value.trim();
            if (value === "") {
                getId(id).style.borderColor = "red";
                getId(errorId).innerHTML = "*Please Enter Name";
                getId(id).setCustomValidity("*Please Enter Name");
            }
            else {
                if (value.length >= 20 || value.length < 2) {
                    getId(id).style.borderColor = "red";
                    getId(errorId).innerHTML = "*Length Should be between 2 and 20";
                    getId(id).setCustomValidity("*Length Should be between 2 and 20");
                }
                else {
                    if (!(/^[A-Za-z\s]+$/.test(value))) {
                        getId(id).style.borderColor = "red";
                        getId(errorId).innerHTML = "*Enter only Alphabet";
                        getId(id).setCustomValidity("*Enter only Alphabet");
                        console.log(value);
                    }
                    else {
                        getId(errorId).innerHTML = "";
                        getId(id).style.borderColor = "lightgrey";
                        getId(id).setCustomValidity("");
                    }
                }
            }
        },

        isUsernameValid:function(id, errorId)
        {
            var emailId = getId(id).value.trim();
            if (emailId === "") {
                getId(id).style.borderColor = "red";
                getId(errorId).innerHTML = "*Please Enter Email-Id";
                getId(id).setCustomValidity("*Please Enter Email-Id");
            }
            else {
                if (!(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/.test(emailId))) {
                    getId(id).style.borderColor = "red";
                    getId(errorId).innerHTML = "*Enter Proper Email-Id";
                    getId(id).setCustomValidity("*Enter Proper Email-Id");
                }
                else {
                    getId(errorId).innerHTML = "";
                    getId(id).style.borderColor = "lightgrey";
                    getId(id).setCustomValidity("");
                }
            }
        },

        isAddressValid:function(id,errorId)
        {
            var value = getId(id).value.trim();
            if (value === "") {
                getId(id).style.borderColor = "red";
                getId(errorId).innerHTML = "*Please Enter your Address";
                getId(id).setCustomValidity("*Please Enter your Address");
            }
            else {
                if (value.length < 5) {
                    getId(id).style.borderColor = "red";
                    getId(errorId).innerHTML = "*Minimum length should be 5";
                    getId(id).setCustomValidity("*Minimum length should be 5");
                }
                else {
                    getId(errorId).innerHTML = "";
                    getId(id).style.borderColor = "lightgrey";
                    getId(id).setCustomValidity("");
                }
            }
        },

        isPasswordValid:function(id,errorId)
        {
            var password = getId(id).value.trim();
            if (password === "") {
                getId(id).style.borderColor = "red";
                getId(errorId).innerHTML = "*Please Enter Password";
                getId(id).setCustomValidity("*Please Enter Password");
            }
            else {                
                    if (!(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$#!%*?&]{8,}$/).test(password)) {
                        getId(id).style.borderColor = "red";
                        getId(errorId).innerHTML = "Password must be 8 characters and should contain atleast one uppercase+lowercase+digit+special character respectively";
                        getId(id).setCustomValidity("*Please Enter valid Password");
                    }
                    else {
                        getId(errorId).innerHTML = "";
                        getId(id).style.borderColor = "lightgrey";
                        getId(id).setCustomValidity("");
                    }
            }
        },

        isEqual: function(id, errorId, id1) {
            var password = getId(id).value.trim();
            {
                if (password!==getId(id1).value){
                    getId(id).style.borderColor = "red";
                    getId(errorId).innerHTML = "*Entered Password does not match";
                    getId(id).setCustomValidity("*Entered Password does not match");
                }
                else {
                    getId(errorId).innerHTML = "";
                    getId(id).style.borderColor = "lightgrey";
                    getId(id).setCustomValidity("");
                }
            }
        },

        validContact:function(id,errorId)
        {
            var value = getId(id).value.trim();
            if(value==="")
            {
                getId(id).style.borderColor = "red";
                getId(errorId).innerHTML = "*Please Enter Mobile Number";
                getId(id).setCustomValidity("*Please Enter Mobile Number");
            }
            else
            {
                if(!(/^[0-9]{5,12}$/.test(value)))
                {
                    getId(id).style.borderColor = "red";
                    getId(errorId).innerHTML = "*Contact Number length should be between 5 and 12";
                    getId(id).setCustomValidity("*Enter proper Number");
                }
                else
                {                    
                        getId(errorId).innerHTML = "";
                        getId(id).style.borderColor = "lightgrey";
                        getId(id).setCustomValidity("");
                    
                }
            }
        },
        isContactValid: function (cloneCount) {
            
            for(var i=1;i<Number(cloneCount);i++)
            {
                var contact = getId('ContactNumber'+ i).value;
               
                if (contact === "") {
                    getId('ContactNumber' + i).style.borderColor = "red";
                    getId('errorContactInfo' + i).innerHTML = "*Please Enter Mobile Number";
                    getId('ContactNumber' + i).setCustomValidity("*Please Enter Mobile Number");
                }
                else
                {
                    if (!(/^[0-9]{5,12}$/.test(contact))) {
                        getId('ContactNumber' + i).style.borderColor = "red";
                        getId('errorContactInfo' + i).innerHTML = "*Contact Number length should be between 5 and 12";
                        getId('ContactNumber' + i).setCustomValidity("*Enter proper Number");
                    }
                    else {
                        getId('errorContactInfo' + i).innerHTML = "";
                        getId('ContactNumber' + i).style.borderColor = "lightgrey";
                        getId('ContactNumber' + i).setCustomValidity("");

                    }
                }
            }

        },

        userCredentials:function()
        {
            validate.isNameValid('Firstname', 'errorFirstname');
            validate.isNameValid('Lastname', 'errorLastname');
            validate.isUsernameValid('Email', 'errorEmailId');
            validate.isAddressValid('Address', 'errorAddress');
            validate.isPasswordValid('Password', 'errorPassword');
            validate.isEqual('ConfirmPassword', 'errorConfirmPassword', 'Password');
        },
    };

        getId("register").addEventListener("click", function () {
            validate.userCredentials();
        });

       

        
