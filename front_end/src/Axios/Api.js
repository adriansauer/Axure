/**librerias de axios */
import axios from 'axios';

const requestHelper=axios.create(
    {
        baseURL:'http://localhost:53854/'
    }
)

export default {
    productos:{
        get:()=>requestHelper({
            url:'Cars',
            method:'get',

        }),
        post:(data)=>requestHelper({
            url:'products',
            method:'post',
            data
        })
    }

}


