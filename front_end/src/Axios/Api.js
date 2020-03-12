/**librerias de axios */
import axios from 'axios';

const requestHelper=axios.create(
    {
        baseURL:'http://localhost:53049/',
       
    }
)

export default {
    productos:{
        get:()=>requestHelper({
            url:'Products/List',
            method:'get',

        }),
        create:(data)=>requestHelper({
            url:'Products',
            method:'post',
            data
        }),
        delete:(id)=>requestHelper({
            url:'Products/Delete/${id}',
            method:'DELETE',
        }),
        edit:(id,data)=>requestHelper({
            url:'Products/Edit/'+{id},
            method:'put',
            data
        })
    }

}


