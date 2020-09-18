<template>
    <footer class="d-lg-none d-block">






 <Drawer @close="toggle" align="right" @click="toggleMenu2"  :closeable="true" :maskClosable="true">
      <div style="width:250px" v-if="open">
        <div class="mymenu2 w-100 p-2">
          <div v-if="this.$store.state.AllAboutToken">
                  <span style="font-size:20px">{{this.$store.state.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']}}</span>
                  <hr>
                  <router-link v-if="GetRole()"  to="/admin" class="link">
                    <button type="button" class="btn btn-lg  pl-0 w-100 text-left">
                      <img src="../assets/img/админ.png"  id="trash" class="mr-1  pt-1 "/><span style="font-size:15px">Администрирование</span>
                    </button>
                  </router-link>
                  <router-link  to="/login" class="link">
                    <button type="button " @click="Exit()" class="btn btn-lg  pl-0 w-100 text-left">
                      <img src="../assets/img/выйти.png"  id="trash" class="mr-1  pt-1 "/><span style="font-size:15px">Выйти</span>
                    </button>
                  </router-link>  
          </div>

      <div v-if="!this.$store.state.AllAboutToken">
                  <router-link  to="/login" class="link">
                    <button type="button" class="btn btn-lg  pl-0 w-100 text-left">
                      <img src="../assets/img/войти.png"  id="trash" class="mr-1  pt-1 "/><span style="font-size:15px">ВОЙТИ</span>
                    </button>
                  </router-link>
                  <router-link  to="/register" class="link">
                    <button type="button " class="btn btn-lg  pl-0 w-100 text-left">
                      <img src="../assets/img/регистрация.png"  id="trash" class="mr-1  pt-1 "/><span style="font-size:15px">РЕГИСТРАЦИЯ</span>
                    </button>
                  </router-link>  





                  
          </div>

        
      </div>
      </div>
    </Drawer>

    <Drawer @close="toggleMenu2" align="left" :maskClosable="true"  >
      <div style="width:250px" v-if="this.$store.state.openMenu">
        <Menu class="mymenu2 w-100" @start="CloseMenu()" />
      </div>
    </Drawer>

<div class="row pl-3 pt-3 pr-3">
  <div class="col-3 text-center  ">
  <img src="../assets/img/menu.png"  @click="toggleMenu" style="width:21px" class="" alt="">
  </div>
  <div class="col-3  text-center">
 <router-link to="/"><img src="../assets/img/15730.png" style="width:32px" class="mr-1  "/></router-link>
  </div>
  <div class="col-3 text-center">

<router-link to="/order"><img src="../assets/img/корзина-для-сайта-png-5.png" style="width:30px" class=" mr-1 bascketBottom "/></router-link>
        <div style="position:absolute" class="trash_into2"><strong>+{{GetCol()}}</strong></div>


  </div>
  <div class="col-3 text-center">
<img @click="toggle" src="../assets/img/Челл.png" style="width:28px" class="mr-1  "/>
  </div>
</div>


</footer>
</template>
<script>
import Drawer from "vue-simple-drawer"
import Menu from "./Menu.vue"



export default {
  name: "app",
  data() {
    return {
      open: false,
      openMenu:false
    }
  },
  components: {
    Drawer,
    Menu
  },
  methods: {
    async CloseMenu(){
      console.log("123")
      await this.$store.commit('setOpenMenu',false)
      this.$store.commit("setCategory" ,this.$store.state.categories.find(e => e.id ==this.$route.params.idCategory))
    },
    GetRole(){
      return this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'
    },
    Exit(){
      this.$store.dispatch('Exit')
    },
    toggle() {
    
      this.open =!this.open
    },
    toggleMenu() {
   
       this.$store.commit('setOpenMenu',true)
      this.openMenu = !this.openMenu
    },
       toggleMenu2() {
    
       this.$store.commit('setOpenMenu',!this.$store.state.openMenu)
      this.openMenu = !this.openMenu
    },
    GetCol(){
      let k=0
       if(this.$store.state.myItems!=null){
      this.$store.state.myItems.forEach(element => {
        if(element.orderId == null){k++}
      });
       }
      return k
    },
  }
}
</script>

<style scoped>
.trash_into2{
    position:absolute;
    padding-right:5px;
    padding-left:5px;
    background-color:  rgb(255,202,5);
    border-radius:15px;
    font-size:12px;
    color:white;
    left:50%;
    top:0px;
}
</style>