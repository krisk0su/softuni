class CheckingAccount{
    constructor(clientId, email, firstName, lastName ){
        this.clientId = this.setClientId(clientId);
        this.email = this.setEmail(email);
        this.firstName = this.setName(firstName, 'First name');
        this.lastName = this.setName(lastName, 'Last name');
        this.products = [];
    }
    setClientId(clientId){
        let isString = typeof(clientId) !== 'string';
        let isValidNumber = isNaN(clientId);
        let isLengthCorrect = clientId.length !== 6;

        if(isString || isValidNumber || isLengthCorrect){
            throw new TypeError("Client ID must be a 6-digit number");
        }
        return clientId;
    }
    setEmail(email){
        var reg = /[a-zA-Z0-9]+@([a-z]+.|[.]+)[a-z]*/gm;
        if(reg.test(email)){
            return email;
        }

        throw new TypeError("Invalid e-mail");
    }
    setName(name, output){
        if(name.length<3 || name.length > 20){
            throw new TypeError(`${output} must be between 3 and 20 characters long`);
        }
        const regex = /[a-zA-Z]+/gm;
        if(!regex.test(name)){
            throw new TypeError(`${output} must contain only Latin characters`);
        }
        return name;
    }
    
}

let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'Petrov')