function attachEvents(){
    $("#submit").on("click", sendData);
    $("#refresh").on("click", renderData);
    
    let url = "https://messanger-7caa6.firebaseio.com/messages.json"

    function sendData(){

        let name = $('#author').val();
        let message = $('#content').val();
        let timestamp =  Date.now();

        let obj = {
            name,
            message,
            timestamp  
        }

            $.ajax({
                url: url,
                method: 'POST',
                data: JSON.stringify(obj),
                success: () => console.log('we did it')
            })

    }

    function renderData(){
        
        $.ajax({
            url: url,
            success: beUseful,
        })
        function beUseful(data){
            $('#messages').text('')
            let values = Object.values(data);
           
            values.sort(function(obj1, obj2) {
                return obj1.timestamp - obj2.timestamp;
            });

            for (const user of values) {

                
                let name = user['name'];
                let message = user['message'];
                
                $('#messages').append(`${name} : ${message}\n`);

            }
            
        }
    }
}