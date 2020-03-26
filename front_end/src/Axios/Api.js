/**librerias de axios */
import axios from 'axios';
const requestHelper=axios.create(
    {
        baseURL:'http://localhost:53049/',
        /**  headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
          }
    */
  
     
    }
)

export default {
    productos:{
        get:()=>requestHelper({
            url:'Products/List',
            method:'get',

        }),
        create:(data)=>requestHelper({
            url:'/Products/Create',
            method:'post',
            data: data,
            config: { headers: { "Content-Type": "multipart/form-data" } }
        }),
        delete:(id)=>requestHelper({
           
            url:'Products/Delete/'+id,
            method:'delete',
        }
        ),
        edit:(id,data)=>requestHelper({
            url:'Products/Edit/'+id,
            method:'put',
            data
        })
    }

}


