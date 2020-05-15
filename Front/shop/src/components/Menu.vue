
<template>
    <div class="btn-group-vertical btn-group-lg pr-2 curs text-left" role="group" aria-label="Basic example">
       


    <button v-for="category in this.$store.state.categories" :key="category.id" @click="$emit('start')"   type="button" class="btn  text-left  p-1" >
      <router-link   :to="'/items/'+category.id"><div class="mybtnmenu">
      <img   class="mr-1  imgMenu" :src="require('../assets/img/'+category.img)"/>
      <span class="d-inline-block text-left curs ">{{category.name}}</span></div> </router-link>
    </button>
    
    </div>
</template>
<script>
export default {
   
  
    methods:{
    CloseMenu(){
      this.$store.commit('setOpenMenu',false)
    }
}
}
</script>