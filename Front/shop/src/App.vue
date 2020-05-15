<template>
  <div>

   <router-view />
  </div>
</template>

<script>

export default {
  components: {
   
    
  },
  async mounted(){

    console.log(this.$store.state.user)
    console.log('email ' + this.$store.state.isEmail)
    await this.$store.dispatch("CheckRefresh")
     

    await this.$store.dispatch("GetCategories")
    await this.$store.dispatch("GetItems")
  }
}
</script>

