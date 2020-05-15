<template>
<div  style='overflow-x:hidden;margin-left: 0px;'>
  <div  class="mt-0   page-main   "> 

<header  class="m-0 p-0">
  <div  id="header" class="">
    <div class="container-lg pt-1 pb-2 pl-4 ">
      <div class="row">
       <div class="col-8">
    <router-link to="/admin"> <span style="font-size:17px;color:white">Администрирование </span></router-link>
       </div>
         <div class="col-4 text-right ">
           <router-link to="/"><img :src="require('@/assets/img/выйти.png')" style="width:25px"   class=" mr-1 pt-1 "/><span style="font-size:17px;" class="link">Выйти</span> </router-link>
       </div>
      </div>  
    </div>
  </div>    
    </header>




    <div class="container-lg mt-lg-5 mt-4 adminka  "  >
      <div class="row">

        <div class=" col-12">
          <div class="mymenu3 p-3 mb-4">
            <div class="row">
          <div class="col-7 text-left pr-0"> 
            <span><strong>Заказы</strong></span>
          </div>
          <div class="col-5 pl- text-right">
        <b-form-input class="w-100" placeholder="Поиск по номеру " v-model="search" style="font-size:15px"  ></b-form-input>
            </div>
          </div>
          </div>
        </div>

        <div class="col-12">

            


 
  <div v-for="order in orders"  :key="order.id">
  <div v-if="order.show==true && search==''?true: order.id==search" class="mb-4">
<div  class="">
  <div class="row pr-4">
  <div class="col-5 text-left pr-0">
  <span class="d-inline-block pl-0 pt-3 mr-3 "  style="color:rgb(88,89,91);font-size:15px"><strong>Заказ №{{order.id}}</strong></span>
  <button v-if="!ShowEdit(order.id)" @click="editId =order.id"  type="button" class="btn btn-light mb-1 p-1" style="font-size:15px">	&#9998;</button>
  <button v-if="ShowEdit(order.id)" @click="SaveEdit(order)" type="button" class="btn btn-light mb-1 p-1" style="font-size:15px">&#128190;</button>
  </div>
  <div class="col-7 text-right  pl-0 ">
    <div>
    <span v-if="!ShowEdit(order.id)" class="d-block  pt-3"  style="color:rgb(88,89,91);font-size:15px">Статус: {{order.status}}</span>
     <b-form-input v-if="ShowEdit(order.id)" v-model="order.status" style="font-size:15px" class="d-block  mt-2" required ></b-form-input>
     </div>
  </div>
  </div>
        <hr >
          <div v-for="myItem in order.userItems "  :key="myItem.id">
            <div  v-if="myItem.orderId!=null" class="  p-0 mt-2  row p-0 m-0" >
              <div class="col-lg-2  col-4 pl-0 ">
                 <img :src="require('@/assets/img/'+ myItem.itemImg)" style="width:60px" class="mymenu3" alt="">
                </div>
                <div class="col-lg-6 col-8 text-left">
                  <router-link :to="'/item/'+myItem.itemId" ><span class="d-block ml-0"  style="color:rgb(88,89,91);font-size:20px">{{myItem.itemName}}</span></router-link>
                  <span  class=" d-block font-weight-light " style="color:rgb(88,89,91);font-size:15px">{{GetDate(myItem.date)}}</span>
                </div>
                <div class="col-lg-2 col-8 mt-1 pl- pr-0   ">
                  <div class="row">
                  <div class="qty col-lg-12 pt-1 col-6 p-0 pl-lg-3 pr-lg-3 text-center">     
                        <span type="number" class="count"  name="qty">{{myItem.value}} <small> кол.</small></span>       
                    </div>
                    <div class="w-50 text-center text-bottom col-lg-12 col-6 ">       
                    </div>
                    </div>
                </div>
                <div class="col-lg-2 col-4 pl-0 pr-0 pt-1 text-right">
                <span class="d-block ml-0 "  style="color:rgb(88,89,91);font-size:20px">{{myItem.value *myItem.itemCost}} руб</span>
                </div>   
            </div>
            <hr class=" ">   
        </div>
         <div class="row pl-4 pr-4">
  <div class="col-5 text-left pr-0 ">
  </div>
  <div class="col-7 text-right pl-0 ">
<span class="d-block ml-0 "  style="color:rgb(88,89,91);font-size:20px"><strong>Всего: {{order.cost}} руб</strong></span>
  </div>
  </div>
  <hr style="border:2px solid ">
    </div>
</div>
  </div>



        </div>
      </div>
    </div>
  </div>  
  </div>  
</template>


<script>
import axios from 'axios'
import { Sort} from "@/store/func"
import moment from 'moment'
//import swal from 'sweetalert'
export default {
  name: "Main",
  components: {
  
  },
  data(){
    return{
    orders:[],
    editId:"",
    search:null


    }
  },
  async mounted(){

        if(this.$store.state.AllAboutToken && this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'){
        console.log("go")
        this.orders = await this.$store.dispatch("GetAllOrders")
        }
        else{
            this.$router.push('/')
        }
    
  },
  methods:{
       async GetOrdersByUser(){
      await this.$store.dispatch("CheckRefresh")
      var config ={headers:{ Authorization :"Bearer "+ this.$store.state.AllAboutToken.accessToken}}
      await axios.get('http://localhost:5000/api/order/user/'+this.$route.params.idUser,config).then(response =>{
      this.orders = Sort(response.data)
    }).catch(function (error) {console.log(error)});
     
    
},
   GetDate(date){
      return moment(date).format('LLL');
    },
    ShowEdit(id){
      return this.editId ==id
    },
    async SaveEdit(order){
      console.log(order)
      await this.$store.dispatch("EditOrder",order)
      this.editId = ""
    }
  
}
}
</script>
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 