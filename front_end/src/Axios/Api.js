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
        getDeposito:(deposito)=>requestHelper({
            url:'Products/OfDeposit/'+deposito,
            method:'get',
        }),
        create:(data)=>requestHelper({
            url:'Products/Create',
            method:'post',
            data: data,
           
        }),
        delete:(id)=>requestHelper({
           
            url:'Products/Delete/'+id,
            method:'delete',
        }
        ),
        edit:(id,data)=>requestHelper({
            url:'Products/Edit/'+id,
            method:'put',
            data:data,
        }),
        getCapital:(deposito)=>requestHelper({
            url:'Products/SumDeposit/3',
            methot:'get',

        })
    }

}


