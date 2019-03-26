let result = (function result(){
    let url = "https://judgetests.firebaseio.com/schedule/";
    let currentStop = "depot.json";
    

    function depart(){
        
        $.ajax({
            url:url+currentStop,
            success: doingSomething
          
        })

        function doingSomething(data){
            let name = data['name'];
            $('#info span').text(`Next stop is ${name}`)

            $('#depart').prop('disabled', true)
            $('#arrive').prop('disabled', false)
        }

        
    }
    function arrive(){
        $.ajax({
            url:url+currentStop,
            success: doingSomething
          
        })

        function doingSomething(data){
            let name = data['name'];
            $('#info span').text(`Arriving at ${name}`)

            $('#arrive').prop('disabled', true)
            $('#depart').prop('disabled', false)
        }
    }
    return{
        depart,
        arrive
    }
})()