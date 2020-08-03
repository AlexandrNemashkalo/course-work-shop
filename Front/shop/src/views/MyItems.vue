<template>
<div  style='overflow-x:hidden;margin-left: 0px;'>

  <!--<Spiner/>-->

  <div  class="mt-0   page-main   "> 
    <Header/>



    
    <div class="container-lg mt-lg-5 pl-lg-0 pt-4    ">
    <span  class="curs pt-lg-5 d-block text-left " style="color:rgb(88,89,91);font-size:20px "><strong class="curs">Корзина</strong></span> <br> <br>
    <div class="row">
        <div class="col-lg-8 col-12">
<div >



<div v-if="this.$store.state.myItems.filter(e => e.orderId ==null).length >0 ">
      <div v-for="myItem in this.$store.state.myItems " :key="myItem.id">
            <div  v-if="myItem.orderId==null" class=" mymenu2 p-4 mt-2  row p-0 m-0" >
           
              <div class="col-lg-2  col-4 pl-0 ">

                 <router-link :to="'/item/'+myItem.itemId" >
                 <img :src="'http://localhost:5555'+myItem.itemImg" class="mymenu3" style="width:100px" alt="">
                 </router-link>

                </div>
                <div class="col-lg-6 col-8 text-left">
                  <router-link :to="'/item/'+myItem.itemId" ><span class="d-block ml-0 curs"  style="color:rgb(88,89,91);font-size:20px">{{myItem.itemName}}</span></router-link>
                  <span class="d-block mt-3 btnDelete curs"  @click="DeleteMyItem(myItem.id)"  style="color:rgb(88,89,91);font-size:15px">Удалить</span><br>
                  <span  class=" d-block font-weight-light " style="color:rgb(88,89,91);font-size:15px">{{GetDate(myItem.date)}}</span>

                </div>
                <div class="col-lg-2 col-8 mt-1 pl- pr-0   ">
                  <div class="row">
                  <div class="qty col-lg-12 pt-1 col-6 p-0 pl-xl-3  pr-lg-3 ">
                        <span class="minus bg-dark" @click="EditValue(myItem,'-')" >-</span>
                        <input type="number" class="count" @change="EditValue(myItem,'+',1)" name="qty" v-model="myItem.value">
                        <span class="plus bg-dark" @click="EditValue(myItem,'+')">+</span>
                    </div>
                    <div class="w-50 text-center text-bottom col-lg-12 col-6 ">
                      <label>
                      <input type="checkbox" id=chek class="option-input checkbox mr-lg-4  " @change="EditValue(myItem,'+',1)" v-model="myItem.status" style="top:-2px" checked /></label>
                    </div>
                    </div>
                </div>
                <div class="col-lg-2 col-4 pl-0 pr-0 pt-1 text-right">
                <span class="d-block ml-0 "  style="color:rgb(88,89,91);font-size:20px">{{myItem.value *myItem.itemCost}} руб</span>
                </div>
            </div>
        </div>
      </div>

      <div v-else class="mymenu2 overflow-hidden" >
    <img :src="require('../assets/img/пуст.jpg')" style="width:100%" alt="">

      </div>

            </div>
    
        </div>

        <div class="col-lg-4 col-12 mt-lg-2 pr-lg-0  mt-4">
          <div>
            <div class="mymenu2 p-2">
                <span class="d-block ml-0 text-center"  style="color:rgb(88,89,91);font-size:20px"><strong > Итого: {{GetCol()}} товар на {{GetCost()}} руб</strong></span>
            </div>
            <button class="btn btn-warning mt-2 w-100 btn-lg" @click="AddOrder()" style="border-radius:10px"><span class=" pt-3"  style="color:rgb(88,89,91);font-size:20px;color:white;"><strong>Оформить заказ</strong></span><br></button>
          </div>
        </div>



          <div v-if="this.$store.state.recoms.length >0" class="col-12 mt-4">
                 <span  class="curs pt-5 d-block text-left " style="color:rgb(88,89,91);font-size:20px "><strong class="curs">Рекомендации</strong></span> <br>
          </div>
          <div class="col-12">
            <Recom :recoms="this.$store.state.recoms" />

          </div>




        <div class="col-12 ">
          <span  class="curs pt-5 d-block text-left " style="color:rgb(88,89,91);font-size:20px "><strong strong class="curs">Ваши покупки</strong></span> <br>
        </div>




        
        <div class="col-lg-8 col-12">


<div v-if="this.GetOrder().length >0">

<div v-for="order in this.GetOrder()"  :key="order.id">
  <div v-if="order.show==true" class="mb-4">
<div  class="mymenu2">
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

              <img :src="'http://localhost:5555'+myItem.itemImg" style="width:100px" class="mymenu3" alt="">

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
<span class="d-block mt-3 btnDelete" @click="DeleteOrder(order)"   style="color:rgb(88,89,91);font-size:15px">Удалить</span><br>
  </div>
  <div class="col-7 text-right pl-0 ">
<span class="d-block ml-0 "  style="color:rgb(88,89,91);font-size:20px"><strong>Всего: {{order.cost}} руб</strong></span>
  </div>
  </div>



    </div>
</div>
  </div>
</div>

 <div v-else class="mymenu2 overflow-hidden text-center" >
<span class="d-block ml-0 "  style="color:rgb(88,89,91);font-size:20px"><strong>тут пусто</strong></span>

      </div>





        </div>
    </div>
    
    </div>

    
    </div>

<img class="mb-lg-0  pb-lg-0 mb-4 mt-5 pb-5 d-none" style="width:100%; box-shadow:0px -10px 15px  rgba(153, 152, 152, 0.4);filter: alpha(Opacity=50);
    opacity: 0.3; " src="https://sun9-21.userapi.com/c857724/v857724130/196767/68MTpTCWoEE.jpg"  alt="">
<BottomMenu class=" d-none" />


  </div>  


</template>


<script>
import moment from "moment"
import Header from "../components/Header.vue"
import $ from 'jquery'
import Recom from "../components/Recom.vue"
import BottomMenu from "../components/BottomMenu.vue"

export default {
  name: "Main",
  components: {
     // Spiner,
     Header,
     BottomMenu,
     Recom
     
  },
  data(){
    return{
      orders:[],
      Recoms:[]
    }
  },
  async mounted(){
          $(function(){
$(window).scrollTop(0);
  })
    if(this.$store.state.AllAboutToken != null){

      await this.$store.dispatch('GetMyItems')
       await this.$store.dispatch('GetOrders')
      await this.GetRecom()
      }
  },
  methods:{
    GetRecom(){
      if(this.$store.state.myItems.length >0){
    
      this.$store.dispatch('GetCoolRecoms')
      }
      else{
          this.$store.commit("setRecoms",[])
      }
    },
    DeleteOrder(ord){
      ord.show = false;
      this.$store.dispatch('EditOrder',ord)
    },
    GetOrder(){
      return this.$store.state.orders.filter(e => e.show == true)
    },
   async AddOrder(){
      if(this.GetCol()>0){
      await this.$store.dispatch('AddOrder')
      }
    },
    async EditValue(myItem, z ,k=null){
      var Order = myItem
      if(z=='-'){
        if(Order.value == 1){
          console.log('ниче')
        }
        else{
          myItem.value --
          await this.$store.dispatch("EditMyItem",myItem) 
        }
      }
      else{
        if(k==null){
        myItem.value ++}
        
        await this.$store.dispatch("EditMyItem",myItem) 
      }

    
    },
    GetCol(){
      let k=0
      if(this.$store.state.myItems!=null){
      this.$store.state.myItems.forEach(element => {
        if(element.status == true){k++}
      });
      }
      return k
    },
    GetCost(){
      let k=0
       if(this.$store.state.myItems!=null){
      this.$store.state.myItems.forEach(el => {
        if(el.status == true){k =k+ el.value*el.itemCost}
      });
       }
      return k
    },
    GetDate(date){
      return moment(date).format('LLL');
    },
    DeleteMyItem(id){
      console.log("delete")
       this.$store.dispatch("DeleteMyItem",id) 
    },
  addImg(){
  return this.$store.state.img
}
  }
}






</script>