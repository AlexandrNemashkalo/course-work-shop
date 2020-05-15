<template>
<div  style='overflow-x:hidden;margin-left: 0px;'>

  <!--<Spiner/>-->

  <div  class="mt-0   page-main   "> 
    <Header/>
    <div class="container-lg mt-lg-5 pl-lg-0 pt-lg-4  pr-lg-0 ">
    <div class="row pt-lg-5 pt-3">
      <div class="col-12">
                <span  class="curs " style="color:rgb(88,89,91);font-size:30px"><strong class="curs">{{this.$store.state.item.name}}</strong></span>
      </div>
      <div class="col-12">
        <div class="mymenu2 p-4">
          <div class="row product-item ">
           
            <div class="col-lg-4 col-12 pr-lg-0">
               <img :src="require(this.$store.state.item.status==true?'../assets/img/есть.png':'../assets/img/нет.png') "  class="flagItem d-block d-lg-none" alt="">
                <img :src="require('../assets/img/'+this.$store.state.item.img)" class="mymenu3" :id="'fly'+this.$store.state.item.id "  style="width:100%" alt="123">

    <div class="container ml-0">
	<div class="row">
	<div :class="'rating rating/'+this.item.id" style="position:relative">
   
      <input @click="Star(10)"  type="radio" :id="'star/10/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id" value="10" /><label :for="'star/10/'+this.$store.state.item.id" >5 stars</label>
      <input @click="Star(9)" type="radio" :id="'star/9/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id"   value="9" /><label :for="'star/9/'+this.$store.state.item.id" >4 stars</label>
      <input @click="Star(8)" type="radio" :id="'star/8/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id"  value="8"  /><label :for="'star/8/'+this.$store.state.item.id" >3 stars</label>
      <input @click="Star(7)" type="radio" :id="'star/7/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id" value="7" /><label :for="'star/7/'+this.$store.state.item.id" >2 stars</label>
      <input @click="Star(6)" type="radio" :id="'star/6/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id"  value="6"  /><label :for="'star/6/'+this.$store.state.item.id" >1 star</label>
      <input @click="Star(5)" type="radio" :id="'star/5/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id"  value="5" /><label :for="'star/5/'+this.$store.state.item.id" >5 stars</label>
      <input @click="Star(4)" type="radio" :id="'star/4/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id"   value="4" /><label :for="'star/4/'+this.$store.state.item.id" >4 stars</label>
      <input @click="Star(3)" type="radio" :id="'star/3/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id" value="3" /><label :for="'star/3/'+this.$store.state.item.id" >3 stars</label>
      <input @click="Star(2)" type="radio" :id="'star/2/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id"  value="2"  /><label :for="'star/2/'+this.$store.state.item.id">2 stars</label>
      <input @click="Star(1)" type="radio" :id="'star/1/'+this.$store.state.item.id" :name="'rating/'+this.$store.state.item.id"   value="1" /><label :for="'star/1/'+this.$store.state.item.id">1 star</label>
     <div style="position:absolute;right:0">{{this.$store.state.item.kStars}}</div>
    </div >
    
    </div>
    
	</div>
                <!--<Stars :item="this.$store.state.item" class=" Stars2"/>-->
            </div>
            <div class="col-lg-4 col-12 pl-lg-5">
              <div class=" pl-lg-5 ">
                <div class="">
                 <span class="d-block mb-5 ml-0"  style="color:rgb(88,89,91);font-size:50px"><strong >{{this.$store.state.item.cost}} руб</strong></span>
                 <button class="btn btn-lg btn-warning product-order " @click="AddMyItem(null,item)" style="color:white;font-size:48px;"><strong> Купить</strong></button>
                
              </div >
                 <span class="d-block ml-0 mt-5 curs"  style="color:rgb(88,89,91);font-size:25px">
                   <img src="..\assets\img\Карта.png" class="pb-2 " style="width:25px" alt="">
                   <strong class="curs"> Опплата</strong> <br> Карта ,наличные</span>
              </div>
            

            </div>
            <div class="col-lg-4 col-12 pl-lg-5">
               <img :src="require(item.status==true?'../assets/img/есть.png':'../assets/img/нет.png') "  class="flagItem d-none d-lg-block" alt="">
              <div class=" pl-lg-5">
                 <span class="d-block ml-0 mt-3"  style="color:rgb(88,89,91);font-size:25px">
                   
                   <img src="..\assets\img\Состав.png" style="width:25px" class="pb-2" alt="">
                   
                   <strong class="curs"> Состав</strong></span>
                   
                 <span class="d-block ml-0 curs"  style="color:rgb(88,89,91);font-size:25px">{{this.$store.state.item.text}}</span>
                 <hr>
                 <span class="d-block ml-0 curs"  style="color:rgb(88,89,91);font-size:25px">Количество грамм:  {{this.$store.state.item.grams}}</span>
                
              </div>
            </div>
          </div>
          
        </div>
      </div>

          <div v-if="GetTopRecoms().filter(e=>e.status==true).length >0" class="col-12 mt-4">
                <span  class="curs " style="color:rgb(88,89,91);font-size:30px"><strong class="curs">Рекомендации</strong></span>
          </div>

          <div class="col-12">
            <hooper   :itemsToShow="3" :wheelControl="false"      id="hooper2" >
  <slide v-for="(recom,indx) in GetTopRecoms().filter(e=>e.status==true)" :key="indx" :index="indx" class="m-2 slide  " style="position:relative;">
      <div  class="mymenu2  pt-2 pl-4 h-100 w-100" style="position:absolute;color:rgb(88,89,91)">
          <span  @click="Perez(recom.id)" class="curs btnDelete " style="color:rgb(88,89,91);font-size:20px"><strong class="curs">{{recom.name}}</strong></span>
          <div class=" row w-100 h-100 product-item">
              <div class="col-8">
            <img @click="Perez(recom.id)" :src="require('../assets/img/'+ recom.img)" :id="'fly'+recom.id "  style="width:100%;border-radius:10px" alt="">
              </div>
              <div class="col-4 pr-1 pl-0  ">
                     <span class="d-block mb-5 ml-0"  style="color:rgb(88,89,91);font-size:25px"><strong >{{recom.cost}} руб</strong></span>
                    <button class="btn btn-lg btn-warning product-order  " @click="AddMyItem(recom.id,recom)" style="color:white;font-size:25px;"><strong> Купить</strong></button>
              </div> 
          </div>
      </div>

  </slide>

 </hooper>
           <!--<Recom @start="Start()" :recoms="GetTopRecoms()" />-->
          </div>
          <div class="col-12 mt-4">
                <span  class="curs " style="color:rgb(88,89,91);font-size:30px"><strong class="curs">Комментарии</strong></span>
          </div>
          <div class="col-12 mt-4">
                <div class="mymenu p-4">
                  <button @click="AddComment()" class="btn btn-lg btn-warning" style="color:white;font-size:25px;"><strong> Оставить отзыв</strong></button>
                  <textarea v-model="text" class="form-control"  style="height:100px;color:rgb(88,89,91);font-size:20px;" aria-label="With textarea"></textarea>
                  <hr>

                <div v-for="comment in this.$store.state.comments" :key ="comment.id" style="position:relative">
                  <button v-if="ShowDelete(comment.userId)" type="button" @click="DeleteComment(comment.id)"  class="btn btn-light btn-sm mybtn  ml-3 " style="position:absolute;font-size:15px;top:5px;right:5px" >	&#10006;</button>
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:25px"><strong>{{comment.userName}}</strong></span>
                    <span  class="curs d-block " style="color:rgb(88,89,91);font-size:20px">{{comment.text}}</span>
                    <span  class=" d-block font-weight-light " style="color:rgb(88,89,91);font-size:15px">{{GetDate(comment.date)}}</span>
                    <div>
      <button class="ma-2" @click="AddLike(comment.id , true)" style="position:absolute;bottom:10px;right:60px;border:none; background-color:white">

        <img src="../assets/img/лайк.jpeg" style="width:25px" class="pr-1">
        <span style="font-size:15px">{{comment.kLikes}}</span>
      </button >

      <button @click="AddLike(comment.id , false)" style="position:absolute;bottom:10px;right:5px;border:none; background-color:white">
        <img src="../assets/img/дизлайк.jpeg" style="width:25px" class="pr-1">
             <span style="font-size:15px">{{comment.kDisLikes}}</span>
      </button>
      
    </div>
      
                    <hr>
                  
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
<BottomMenu class=" d-none" />


  </div>  


</template>


<script>



import Header from "../components/Header.vue"
import BottomMenu from "../components/BottomMenu.vue"
import {
  Hooper,
  Slide,
  } from 'hooper';

import $ from "jquery"
import swal from 'sweetalert'

 import moment from 'moment'
import { mdiThumbDown } from '@mdi/js';
import { mdiThumbUp } from '@mdi/js';



export default {
  name: "Main",
  components: {
     Header,
     BottomMenu,
     Hooper,
    Slide,
  },
  data(){
    return{
      mdiDislike: mdiThumbDown,
      mdiLike: mdiThumbUp,

      star:0,
      item:{},
      rec:[],
      text:"",
      
    }
  },
  async mounted(){
          $(function(){
$(window).scrollTop(0);
  })
   await this.Start(this.$route.params.id)
   await this.Start2()
  },
  methods:{
    AddLike(id,type){
        if(this.$store.state.AllAboutToken != null){
      var form = {
        id:id,
        type:type
      }
   
       this.$store.dispatch("AddLike",form)
        }
        else{
          swal({
  title: "Вам нужно авторизоваться",
  icon: "warning",
        })
        }
    },
    ShowDelete(id){
      if(this.$store.state.AllAboutToken != null){
        return id == this.$store.state.user.sub || this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] =="admin"
      }
      return false
    },
   DeleteComment(id){
              swal({
  title: "Вы действительно хотите удалить коментарий?",
  text: "После удаления товара удалиться все что с ним связано:коментарии,отзывы, покупки",
  icon: "warning",
  buttons: true,
  dangerMode: true,
})
.then((willDelete) => {
  if (willDelete) {
    this.$store.dispatch("DeleteComment",id)
    swal("Товар был успешно удален", {
      icon: "success",
    });
    
  } else {
    swal("Вы сохранили ему жизнь!");
  }
});  
    },
    GetDate(date){
      return moment(date).format('LLL')
    },
    AddComment(){
       if(this.$store.state.AllAboutToken == null){
      swal({
      text: "Вам нужно авторизоваться",
      icon: "warning",});
      }
      else{
        console.log(this.text)
      if(this.text.length==0){
      swal({
            text: "Комментарий не может быть пустым",
            icon: "warning",});
      }
      else{
 
        this.$store.dispatch('AddComment',this.text)
        this.text =""
      }
      }
    },





  Perez(id){
      this.$router.push('/item/'+id)
      location.reload()
       $(function(){
$(window).scrollTop(0);
  })
    },
     AddMyItem(id,item){
       if(this.$store.state.AllAboutToken == null){
      swal({
      text: "Вам нужно авторизоваться",
      icon: "warning",
      });
      }
      else{
      
        if(item.status==true){
       if(id!=null){
         polet(id)
      this.$store.dispatch('AddMyItem',id)
       }
       else{
         polet(this.$route.params.id)
         this.$store.dispatch('AddMyItem',this.$route.params.id)
       }
      }
      else{
        swal({
      text: "В данное время товара нет в наличии",
      icon: "warning",
      });
      }
      }
      
     },
    async Start(id){
  
 console.log("startItem")
    await this.$store.dispatch('GetItemById',id)
    await this.$store.dispatch('GetCommentsByItem')
    if(this.$store.state.AllAboutToken)
    await this.$store.dispatch('Connection')

    this.item = this.$store.state.item
  this. GetTopRecoms()
    },
    GetTopRecoms(){
      var rec = []
    this.$store.state.items.forEach(el => {
     if(el.categoryId ==this.$store.state.item.categoryId && el.id !=this.$store.state.item.id  ){
        rec.push(el)
      }
    });
  this.rec =rec
  var up =rec.sort(function (a, b) {
  if ((a.stars / a.kStars > b.stars / b.kStars || b.kStars==0)&& a.kStars!=0 ) {
    return 1;
  }
  if (a.stars / a.kStars < b.stars / b.kStars || a.kStars ==0) {
    return -1;
  }
  return 0;
});

  return up.reverse()
    },
     async Star(n){
      
        if(this.flag == true){
           if(this.$store.state.AllAboutToken == null){
      swal({
      text: "Вам нужно авторизоваться",
      icon: "warning",
      });
      }
      else{
            this.$store.state.item.top = n
            console.log(n)
            console.log("изменяем")
            await this.$store.dispatch('AddRating',this.$store.state.item)
           
        }
      }
    },
    Start2(){
   console.log('борщец')
   
        if(this.$store.state.item.kStars>0){
              console.log('борщец2')
        var r =document.getElementById('star/'+Math.round(this.$store.state.item.stars/this.$store.state.item.kStars)+'/' + this.$store.state.item.id)
        r.click()
        }
        this.flag =true
      
    },

  addImg(){
    return this.$store.state.img
    }
  }
}





function polet(id){
   console.log(id)
  
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
