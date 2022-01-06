//  DotNet.invokeMethodAsync("Assembly-Name", "Method-Name", Comma-Separated-Parameters)

window.callToCSharp = {
    showMessage: function(){
        DotNet.invokeMethodAsync("Blazor_Wasm", "showMessage")
            .then((result) => {
                alert(`Received Message = ${result}`);
            }).catch((error) => {
                alert(`Error Occurred = ${error}`);
            });
    },
    add: function () {
        DotNet.invokeMethodAsync("Blazor_Wasm", "add", 200,400)
            .then((result) => {
                alert(`Received Add Result = ${result}`);
            }).catch((error) => {
                alert(`Error Occurred = ${error}`);
            });
    },
    getProducts: function () {
        DotNet.invokeMethodAsync("Blazor_Wasm", "getProducts")
            .then((result) => {
                alert(`Received Products Result = ${JSON.stringify(result)}`);
            }).catch((error) => {
                alert(`Error Occurred = ${error}`);
            });
    }
};