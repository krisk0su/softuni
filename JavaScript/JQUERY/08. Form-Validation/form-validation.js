function validate() {

	$('#company:checkbox').on("change",function (){
	   $('#companyInfo').css('display', '')
	})

	$('#submit').click(function submitForm(event) {
		event.preventDefault();
		
		let isValid = true;

		let userName = $('#username').val();
		
		
		if(userName.length < 3 || userName.length > 20){
			console.log(userName)
			$('#username').css('border-color', 'red');
			isValid = false;
		}

		let email = $('#email').val();

		if(!email.includes('@') && !email.includes('.')){
			$('#email').css('border-color', 'red');
			isValid = false;
		}

		let password = $('#password').val();
		let confirm = $('#confirm-password').val();

		let areValid = !((password === confirm) && (password.length>=5 && password.length <=15)
		&& (confirm.length>=5 && confirm.length <=15));

		
		if(areValid){
			$('#password').css('border-color', 'red');
			$('#confirm-password').css('border-color', 'red');
			isValid = false;
		}

		let companyNumber = $('#companyNumber').val();

		if(!companyNumber){
			$('#companyNumber').css('border-color', 'red');
			isValid = false;
		}
		
		if(isValid){
			$('#valid').css('display', '')
		}

	});

}