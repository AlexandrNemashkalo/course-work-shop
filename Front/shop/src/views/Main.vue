<template>
<div   style='overflow-x:hidden;margin-left: 0px;'>

<div v-if="this.showspiner"  style="text-align:center;z-index:10000;background-color: rgba(246,246,246,100%);" class="loginBody">
 <Spiner class="d-inline-block" style=""  />
</div>
  <div   class="mt-0   page-main   "> 
    <Header/>
    <div class="container-lg mt-lg-5 pt-lg-4  pl-lg-0 pr-lg-0 ">
    <div class="row pt-lg-5  pt-3">
        <div class="col-lg-3 col-xl-3  d-lg-block d-none ">
      
          <Menu class="  mymenu  w-100"/>
          
        </div>

        <div class="col-lg-9">
          <div class="row pl-0">
        <div class="col-lg-8 col-12  mt-lg-0 mt-4 " id="boxCar">
          <div class="mymenu2 overflow-hidden p-0">
            <miniKarusel class="w-100"/>
          </div>
          
        </div>
        <div class="col-lg-4 col-12 mt-lg-0 mt-4 pr-lg-4">
          <div id="sobitiya" class="mymenu2 p-3 curs " >
            <span  style="color:rgb(88,89,91);font-size:20px;"><strong class="curs">События</strong></span> <br> <br>

            <span v-for="ev in this.$store.state.events" :key="ev.id" style="color:rgb(88,89,91);font-size:15px" class="curs">{{ev.text}} <br> </span>
           
          </div>
        </div>
        </div>

        <div class="row curs  ">
          <div class="col-12  mt-4 pr-lg-4" >
            <div id="komplex" class="mymenu2 p-3 curs" >
              <div class="row">
<div class="col-9 pr-0">
  <span  style="color:rgb(88,89,91);font-size:20px" ><strong class="curs">Сегодня в комплексе</strong></span> <br> 
  
</div>
<div class="col-3 text-right pl-0">
   <button class="btn btn-lg btn-warning  " @click="AddKomplex('aa01a477-8d72-47a2-9b24-1af6955ffcc4')" style="color:white;font-size:14px;"><strong> Купить</strong></button>
</div>

              </div>
              
              <div class="row ">


                   <div v-for="item in this.$store.state.items.filter(e => e.komplex ==true)" :key="item.id" class="col-md-4 mb-3  pr-0 pr-lg-4 col-6">
                    <router-link :to="'/item/'+item.id"> <span  style="color:rgb(88,89,91);font-size:15px" class="curs">{{item.name}}</span> <br>  </router-link> 
                   <router-link :to="'/item/'+item.id">
                    <img :src="'http://localhost:5555'+item.img"  class="mymenu3 kompImg  d-block"  alt=""> 
                  </router-link> 

                </div>
                   

                
              </div>
            </div>
          
          </div>
        </div>


        </div>
        
      

    </div>
          <div class="row  ml-0 mr-0 mt-4 mb-4 ">

<div class="col-xs-12 marquee mymenu2 curs " style="color:rgb(88,89,91);background-color:white;"><h1>вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота</h1></div>

</div>
<span  class="curs " style="color:rgb(88,89,91);font-size:20px"><strong class="curs">Новости</strong></span> <br> <br>
  <BottomCar class="mb-5"/>
    </div>
 
  <div class="text-center " style="font-size:15px;">
    <hr>
<span >2019-2020   Курсовая работа</span>
    </div>
    

    
 
    </div>

<BottomMenu  v-if="!this.showspiner" class=" d-none" />

  </div>  


</template>


<script>
import Spiner from "../components/Spiner.vue"
import $ from 'jquery'
import Header from "../components/Header.vue"
import Menu from "../components/Menu.vue"


import BottomMenu from "../components/BottomMenu.vue"
import miniKarusel from "../components/miniKarusel.vue"
import BottomCar from "../components/BottomCar.vue"
import swal from 'sweetalert'


		

export default {
  name: "Main",
  components: {
     Spiner,
     Header,
     Menu,
    
     miniKarusel,
     BottomMenu,
     BottomCar,
     //LeftMenu
  },
  data(){
    return{
    showspiner:true

    }
  },
  async mounted(){

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
    this.showspiner=true;
    await sleep(4000);
    this.showspiner=false

    
await this.$store.dispatch("GetNews")
await this.$store.dispatch("GetEvents")
  $(function(){
$(window).scrollTop(0);
  })
  },
  methods:{
   async AddKomplex(id){
      console.log(id)
      await this.$store.dispatch("GetItemById",id)
      var item = this.$store.state.item
 if(item.status ==true){
      if(this.$store.state.AllAboutToken == null){
      swal({
      text: "Вам нужно авторизоваться",
      icon: "warning",
      });
      }
      else{
      swal({
      text: "Комплекс был добавлен в корзину",
      icon: "success",
      });
      this.$store.dispatch('AddMyItem',item.id)
      }
      }
      else{
          swal({
      text: "Комплекс можно заказать с 11:00 до 17:00 ",
      icon: "warning",
      });
      }



    },
  addImg(){
  console.log(this.$store.state.img)
  return this.$store.state.img
}
  }
}
</script>

<style  >
.loginBody{
width: 100%;
    height: 100%;
    position: fixed;
    top: 0;
    left: 0;
    display: flex;
    align-items: center;
    align-content: center; 
    justify-content: center; 
    overflow: auto;
    
}

</style>