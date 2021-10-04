const serverUrl = "https://wavessystems.com.br/t2uxt";
function post(endpoint,data){
    return fetch(serverUrl+"/"+endpoint, {
        method: "POST", 
        body: JSON.stringify(data)
      });
}