<template>

<div  style='overflow-x:hidden;margin-left: 0px;'>

  <!--<Spiner/>-->

  <div  class="mt-0   page-main   "> 
    <Header/>
    <div class="container-lg mt-lg-5 pl-lg-0 pt-lg-4  pr-lg-0 ">
    <div class="row pt-lg-5 pt-3">
        <div class="col-lg-3 d-lg-block d-none   ">
      
          <Menu @start="Start()" class="  mymenu  w-100"/>
          
        </div>
        
        <div class="col-lg-9 col-12">
        <div class="row">
            <div class="col-lg-3 col-12 pr-0">
                <span  class="curs " style="color:rgb(88,89,91);font-size:20px"><strong>{{this.$store.state.category.name}}</strong></span>
            </div>
         
              <div class="col-lg-9 col-12 text-right pl-0 d-lg-block mb-2 ">
                 <img   style="width:15px" class="pb-2 btnDelete " @click="Reverse()"  alt="" :src="require('../assets/img/сорт.png') ">

                 <span  class="curs sort ml-2 " @click="Sort('цена')" style="font-size:15px;cursor:pointer">цена </span>
                 <span  class="curs  ml-2 "  style="font-size:15px;color:rgb(88,89,91)">|</span>
                  <span  class="curs sort  ml-2" @click="Sort('рейтинг')" style="font-size:15px;cursor:pointer">рейтинг</span>
              </div>
             
           
        </div>
       

         <div> 
        
        <div v-for="item in this.$store.state.items" :key="item.id" style="position:relative;overflow: visible">

        <div v-if="ShowList(item.categoryId)"  class="mymenu2  row m-0 w-100 mt-lg-4 mb-3 p-4 product-item " >
           
             <img :src="require(item.status==true?'../assets/img/есть.png':'../assets/img/нет.png') "  class="flag d-lg-none d-block" alt="">
            <div class="col-lg-2  col-4 col-md-2 pl-0 ">
                 <router-link :to="'/item/'+item.id" ><img  style="width:100px" class="mymenu3" alt="" :id="'fly'+item.id" :src="require('../assets/img/'+item.img) "></router-link>
                </div>
                <div class="col-lg-6 col-8 text-left  " >
                  <router-link :to="'/item/'+item.id" > <span class="d-block ml-0 curs"  style="color:rgb(88,89,91);font-size:20px">{{item.name}}</span></router-link>
                  <span class="d-block mt-3 curs"  style="color:rgb(88,89,91);font-size:15px;">{{item.text}}</span>
                    <Stars v-if="flag" :item="item" style="z-index:100" class="Stars" />
                </div>
                <div class="col-lg-2 col-4  mt-1 pl-0 pr-0 mb-5 mb-lg-none pt-lg-5  ">
                    <button class="btn btn-lg btn-warning product-order " @click=" AddMyItem(item)" style="color:white;font-size:15px;">Купить</button>
                </div>
                <div class="col-lg-2 col-8 pl-0 pr-0 text-right pt-lg-5">
                  <img :src="require(item.status==true?'../assets/img/есть.png':'../assets/img/нет.png') "  class="flag d-none d-lg-block" alt="">
                <span class="d-block ml-0"  style="color:rgb(88,89,91);font-size:20px">{{item.cost}} руб</span>
                </div>
        </div>
        </div>

        </div>  
        </div>

    </div>
     
          <div class="row  ml-0 mr-0 mt-4 mb-4 ">

<div class="col-xs-12 marquee mymenu2 curs " style="color:rgb(88,89,91);background-color:white;"><h1>вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота вкуснота</h1></div>

</div>

    </div>
 
    </div>

<img class="mb-lg-0  pb-lg-0 mb-4 mt-5 pb-5 d-none" style="width:100%; box-shadow:0px -10px 15px  rgba(153, 152, 152, 0.4);filter: alpha(Opacity=50);
    opacity: 0.3; " src="https://sun9-21.userapi.com/c857724/v857724130/196767/68MTpTCWoEE.jpg"  alt="">
<BottomMenu style="z-index:101" class="  d-none" />


  </div>  
</template>

<script>
//import Spiner from "../components/Spiner.vue"
import Header from "../components/Header.vue"
import Menu from "../components/Menu.vue"
import Stars from "../components/Stars.vue"
import BottomMenu from "../components/BottomMenu.vue"
import swal from 'sweetalert'





export default {
  name: "Main",
  components: {
     Header,
     Menu,
     BottomMenu,
     Stars,
   
  },
  data(){
    return{
flag:true,
    }
  },
  mounted(){
          $(function(){
$(window).scrollTop(0);
  })
console.log("45")
this.$store.commit('setOpenMenu',false)
this.Start()
  },
  methods:{
    Start(){

      this.$store.commit("setCategory" ,this.$store.state.categories.find(e => e.id ==this.$route.params.idCategory))
        
    },
    Sort(param){
      if(param =="рейтинг"){
        var up =this.$store.state.items.sort(function (a, b) {
        if ((a.stars / a.kStars > b.stars / b.kStars || b.kStars==0)&& a.kStars!=0 ) {
          return 1;
        }
        if (a.stars / a.kStars < b.stars / b.kStars || a.kStars ==0) {
          return -1;
        }
        return 0;
      })
       this.$store.commit('setItems',up)
      }
      else if(param =="цена"){
            var up2 =this.$store.state.items.sort(function (a, b) {
        if (a.cost > b.cost ) {
          return 1;
        }
        if (a.cost< b.cost ) {
          return -1;
        }
        return 0;
      })
       this.$store.commit('setItems',up2)
      }
    },
    
    Reverse(){
      this.$store.commit('setItems',this.$store.state.items.reverse())
    },

    AddMyItem(item){
      if(item.status ==true){
      if(this.$store.state.AllAboutToken == null){
      swal({
      text: "Вам нужно авторизоваться",
      icon: "warning",
      });
      }
      else{
      polet(item.id)
      this.$store.dispatch('AddMyItem',item.id)
      }
      }
      else{
          swal({
      text: "В данное время товара нет в наличии",
      icon: "warning",
      });
      }
    },
    ShowList(id){
      return id ==this.$route.params.idCategory
    },
  addImg(){

  return this.$store.state.img
},

  }
}




import $ from "jquery"

 function polet(id){

  
    var that = $($(".product-order")).closest('.product-item').find($("#fly"+id));
    if(window.innerWidth >990){
    var bascket = $(".bascket")}
    else{
     bascket = $(".bascketBottom")}
    
    var w = that.width();

     
    that.clone()
        .css({'width' : w,
        'position' : 'absolute',
        'z-index' : '9999',
        top: that.offset().top,
        left:that.offset().left})
        .appendTo("body")
      .animate({opacity: 0.05,
            left: bascket.offset()['left'],
            top: bascket.offset()['top'],
            width: 20}, 1000, function() {  
                $(this).remove();
            });
}
</script>
