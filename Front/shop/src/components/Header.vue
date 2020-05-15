<template>
<header  class="m-0 p-0">
  <div  id="header" class="">
    <div class="container-lg pt-1 pb-2 d-none d-lg-block pr-lg-0 pl-lg-0">
      <div class="row">
        <div class="col-4"> 
        <img src="..\assets\img\w384h5121380476908location.png" style="width:12px" class=" pb-1"/>
        <span class="textHeader">
           <a href="https://goo.gl/maps/gQxRuFwvcosH6arv7" target="_blank" style="color:white;"> <strong > улица Таллинская, д.34</strong></a></span>
        </div>
        <div class="col-4 text-center">
        <span class="textHeader"> <strong>+7-916-27-56-445 (Пн-Сб 9.00-17.00)</strong></span>
        </div>
        <div class="col-4 text-right">
          <span v-if="this.$store.state.AllAboutToken"  class="textHeader pr-3"   ><strong >{{this.$store.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']}}</strong></span>
         <span v-if="this.$store.state.AllAboutToken"  @click="Exit" class="textHeader link" style="cursor:pointer"  ><strong >Выйти</strong></span>
          <router-link v-if="!this.$store.state.AllAboutToken"  to="/login" class="link"><span class="textHeader" ><strong>Войти</strong></span></router-link>
          <router-link v-if="!this.$store.state.AllAboutToken"  to="/register" class="link"><span class="ml-2 mr-1 textHeader"><strong>Регистрация</strong></span> </router-link> 
        </div>
      </div>  
    </div>
  </div>

  <div id="headerBack" class=" d-lg-block d-none">
    <div class="container-lg pt-1 pb-1 pl-lg-0   pr-lg-0">
      <div class="row">
        <div class="col-lg-3 pt-3">
      <router-link to="/"><img src="..\assets\img\1200px-Логотип_МИЭМ.svg.png" id="miem" class="  "/>
      <strong class="mt-3" style="position:absolute;top:8px;font-size:20px;   color: rgb(255,202,5);"> СТОЛОВАЯ</strong>
      </router-link>
       
        </div>
        

          <div class="col-lg-6  p-1 col-5 pt-0 pr-4 pl-4 text-left">
            <autocomplete 
           :get-result-value="getResultValue"
            :autoSelect ="true"
            :search="search"
             placeholder="Поиск по товарам"
             @submit="handleSubmit"
            
            
            ></autocomplete>
            
    


        </div>
        <div class="col-lg-2 col-0 pt-1 text-left pt-3 pl-4 ">
<b-dropdown variant="warning" id="dropdown-1" size="lg" class=" mr-4" >
    <template v-slot:button-content>
     <strong style="color:white;font-size:15px;">Категории</strong>
    </template>
    <div>
    <Menu @start="Start()" />
    </div>
  </b-dropdown>
        </div >
        <div class="col-lg-1 col-2 pl-0 text-right trash pt-3  "> 
          <div class="row">
            <div class="col-4 pl-0">
      <router-link v-if="GetRole()" to="/admin" class="link"><img src="..\assets\img\админ.png"  id="trash" class="mr-1  pt-1 "/></router-link>
            </div>
             <div class="col-8 pr-5">
                 <router-link to="/order" class="link"><img src="..\assets\img\корзина-для-сайта-png-5.png"  id="trash" class="mr-1 bascket  pt-1 "/></router-link>
                  <div class="trash_into  " ><strong>+{{GetCol()}}</strong></div>
            </div>
          </div>
      
  
        
      </div>

      </div>

    </div>
    
  </div>

    <div  style="background-color: white;width:100%;height:100px; " class=" d-lg-none d-block ">
    
      <div class="row pb-2" style=" box-shadow:0px 10px 15px   rgba(153, 152, 152, 0.4);background-color: white">
        <div class="col-5 text-right">
           <img src="..\assets\img\1200px-Логотип_МИЭМ.svg.png" style="width:100px;" class=" pt-3 pr-0 "/>
        </div>
        <div class="col-7 text-left pl-0 pt-1">
          
        <strong class="mt-1 curs" style="color:rgb(255,202,5);font-size:30px;pardig-left:0"> СТОЛОВАЯ</strong> 
        </div>
        <div class="col-12 pl-5 pr-5 ">
      
         <autocomplete 
           :get-result-value="getResultValue"
            :autoSelect ="true"
            :search="search"
             placeholder="Поиск по товарам"
             @submit="handleSubmit"
            
            
            ></autocomplete>

        </div>
      </div>  
  </div>


  
    </header>
</template>
<script>

import $ from 'jquery'
import Menu from "./Menu.vue"

$(function(){
    $(window).scroll(function() {
    var top = $(document).scrollTop();
    if (top < 28) $("#headerBack").css({top: '29px', position: 'absolute'});
    else $("#headerBack").css({top: '0', position: 'fixed'});
    });
    });
    
export default {
  name: "Header",
  components: {
    Menu,
 
    
  },
  data() {
    return {
      a:true,
      countries:["ada","svvs","svdv"]
    }
},
watch: {
    $route(to, from) {
      if(from.name =="Item"){
          location.reload()
      }

    }
},
methods:{
  Start(){

      this.$store.commit("setCategory" ,this.$store.state.categories.find(e => e.id ==this.$route.params.idCategory))
        
    },
  handleSubmit(result) {
    this.$router.push('/item/'+result.id)
    },
  search(input) {
      if (input.length < 1) { return [] }
      return this.$store.state.items.filter(item => {
        return item.name.toLowerCase()
          .startsWith(input.toLowerCase())
      })
      
    },
     getResultValue(result) {
      return result.name
    },
   GetRole(){
     if(this.$store.state.user)
     {
      return this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'
     }
     else{
       return false
     }
    },
  Exit(){
    this.$store.dispatch('Exit')
  },
   GetCol(){
      let k=0
      if(this.$store.state.myItems!=null){
      this.$store.state.myItems.forEach(element => {
        if(element.orderId == null){k++}
      });}
      return k
    },
}
}
</script>
<style >
.autocomplete-result-list{
  font-size:15px;
}
.autocomplete-input{
padding: 0px 0px 0px 0px;
}
</style>