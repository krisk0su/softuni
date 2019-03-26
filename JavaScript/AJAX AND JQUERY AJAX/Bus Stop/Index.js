function getInfo(){

    let busStop = $('#stopId').val();
    
    let baseUrl = "https://judgetests.firebaseio.com/businfo/";

        $.ajax({
            url: baseUrl+busStop+'.json',
            success: renderData,
            error: appendError
        })
    

    function renderData(data){
        let busName = data['name'];
        $('#stopName').text(busName);
        
        let entries = Object.entries(data['buses'])
        let ul = $('#buses');

        for (const [bus, minutes] of entries) {
            
            ul.append(`<li>Bus ${bus} arrives in ${minutes} minutes.</li>`)
          }
    }
    function appendError(){
     
        $('#stopName').text("Error");
    }
};