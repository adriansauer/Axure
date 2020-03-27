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
        getMateriaPrima:()=>requestHelper({
            url:'Products/OfDeposit/1',
            method:'get',
        }),
        getProductoTerminado:()=>requestHelper({
            url:'Products/OfDeposit/3',
            method:'get',
        }),
        getProductoEnProduccion:()=>requestHelper({
            url:'Products/OfDeposit/2',
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


