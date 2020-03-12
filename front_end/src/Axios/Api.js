/**librerias de axios */
import axios from 'axios';

const requestHelper=axios.create(
    {
        baseURL:'http://localhost:53049/'
    }
)

export default {
    productos:{
        get:()=>requestHelper({
            url:'Products/Everybody',
            method:'get',

        }),
        create:(data)=>requestHelper({
            url:'Products',
            method:'post',
            data
        })
    }

}


