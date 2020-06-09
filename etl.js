const axios = require ('axios');
(async ()=>{
    const {data : {token}} =await axios.post('http://localhost:3000/auth/login',{
        username: 'onno',
        password: '123456',

    });

    const {data} = await axios.get('http://localhost:3000/auth',
    {headers: {authorization: 'Bearer ${token}'}});


    console.log(data);
})();