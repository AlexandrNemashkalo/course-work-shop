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
            <span><strong>{{user.name}}</strong></span>
          </div>
          <div class="col-5 pl- text-right">
            <!--<button v-if="!showEdit" type="button"   @click="showEdit=true" class="btn btn-light btn-sm mybtn  " style="font-size:15px" >&#9998;</button> 
            <button v-if="showEdit" type="button"  @click="Edit()"  class="btn btn-light btn-sm mybtn  " style="font-size:15px" >Сохранить</button>-->
            </div>
          </div>
          </div>
        </div>

        <div class="col-12">

          <div class=" row  pr-0 text-left mb-3">
            <div class="col-2"><span> <strong>Имя:   </strong> </span> </div>
            <div class="col-10">
              <span> {{user.name}} </span>
            </div>
          </div>

          <div class=" row  pr-0 text-left mb-3">
            <div class="col-2"><span> <strong>Email:   </strong> </span> </div>
            <div class="col-10">
              <span> {{user.email}} </span>
           
            </div>
          </div>

          <div class=" row  pr-0 text-left mb-3">
            <div class="col-2"><span> <strong>Статус:   </strong> </span> </div>
            <div class="col-10">
              <span v-if="!showEdit"> {{user.isAdmin==true?'admin':'user'}}  </span>
            <input v-if="showEdit" type="text" style="border:1px solid gray" v-model="user.isAdmin" class="w-50 pl-2">
            </div>
          </div>

        </div>
              <div class="col-12 text-left ">

<div class="tabs">
    <input id="tab1" type="radio" name="tabs" checked>

    <label for="tab1" title="Вкладка 1">Заказы</label>
 
    <input id="tab2" type="radio" name="tabs">
    <label for="tab2" title="Вкладка 2">Коментарии</label>
 
    <input id="tab3" type="radio" name="tabs">
    <label for="tab3" title="Вкладка 3">Отзывы</label>
 
 
 
    <section id="content-tab1">
      <div v-for="order in orders"  :key="order.id">
  <div v-if="order.show==true" class="mb-4">
<div  class="">
  <div class="row pr-4">
  <div class="col-5 text-left pr-0">
  <span class="d-block pl-4 pt-3 "  style="color:rgb(88,89,91);font-size:15px"><strong>Заказ №{{order.id}}</strong></span>
  </div>
  <div class="col-7 text-right pl-0 ">
    <span class="d-block  pt-3"  style="color:rgb(88,89,91);font-size:15px">Статус: {{order.status}}</span>
  </div>
  </div>
        <hr class="ml-4 mr-4">
          <div v-for="myItem in order.userItems "  :key="myItem.id">
            <div  v-if="myItem.orderId!=null" class="  p-4 mt-2  row p-0 m-0" >
              <div class="col-lg-2  col-4 pl-0 ">
                 <img :src="require('@/assets/img/'+ myItem.itemImg)" style="width:80px" class="mymenu3" alt="">
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
            <hr class="ml-4 mr-4">   
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
  

    </section>  
    <section id="content-tab2">
       
                <div v-for="comment in comments" :key ="comment.id">
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:25px"><strong>{{comment.userName}}</strong></span>
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:20px">{{comment.text}}</span>
                    <span  class=" d-block font-weight-light " style="color:rgb(88,89,91);font-size:15px">{{GetDate(comment.date)}} | {{comment.itemName}}</span>
                    <hr>
                </div>
    </section> 
    <section id="content-tab3">
        <div v-for="rating in ratings" :key ="rating.id">
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:25px"><strong>{{rating.itemName}}</strong></span>
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:20px">{{rating.star}} звезд</span>
                    <span  class=" d-block font-weight-light " style="color:rgb(88,89,91);font-size:15px">{{GetDate(rating.date)}}</span>
                    <hr>
                </div>
    </section> 
 
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
        user:{},
        showEdit:false,
        orders:[],
        comments:[],
        ratings:[]
    }
  },
  async mounted(){

        if(this.$store.state.AllAboutToken && this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'){
   

        
        this.user = this.$store.state.users.find(e=> e.id == this.$route.params.idUser)
        await this.GetOrdersByUser()
         await this. GetCommentsByUser()
         await this. GetRatingsByUser()
        }
        else{
            this.$router.push('/')
        }
  },
  methods:{
    Edit(){
      this.showEdit = false
    },

     async GetRatingsByUser(){
      var config ={headers:{ Authorization :"Bearer "+ this.$store.state.AllAboutToken.accessToken}}
      await axios.get('http://localhost:5000/api/rating/user/'+this.$route.params.idUser,config).then(response => {
      this.ratings = Sort(response.data)
  }).catch(function (error) {console.log(error)});
    },

       async GetCommentsByUser(){
      var config ={headers:{ Authorization :"Bearer "+ this.$store.state.AllAboutToken.accessToken}}
      await axios.get('http://localhost:5000/api/chat/user/'+this.$route.params.idUser,config).then(response => {
     
      this.comments = Sort(response.data)
  }).catch(function (error) {console.log(error)});
    },
    
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
}
  
}
</script>
