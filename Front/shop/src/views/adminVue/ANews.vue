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
            <span><strong>Новости</strong></span>
          </div>
          <div class="col-5  text-right">
              <button v-if="!showAdd" type="button" @click="showAdd=true" class="btn btn-success">Добавить</button>
            </div>
          </div>
          </div>
        </div>
      <div class="col-12">





            <div class="mymenu3 p-3 mb-2 d-md-block d-none">
              <div class="row">
                  <div class="col-md-5 col-5  pr-0 text-left">
                    <span> <strong>Текст  </strong> </span>
                  </div>
                  
                   <div class="col-md-3 col-6 pl-0">
                    <span> <strong>Изображение</strong> </span>
                  </div>
                      <div class="col-md-4 col-6 pl-0">
                    <span> <strong>Ссылка</strong> </span>
                  </div>
                    
              </div>
            </div>


             <div v-if="showAdd"  class="mymenu3 m-0 w-100 mt-lg-4 mb-3 p-3 product-item " style="position:relative;" >
        <button type="button" @click="showAdd=false" style="position:absolute;top:36px;right:5px;z-index:6" class="btn btn-warning">&#10006;</button>

            <form action="" @submit.prevent="AddCategory" class="w-100 pl-4 pt-3 row ">
           <div class="col-md-5  pl-0">
             <div>
                <span class="d-md-none d-inline-block"> <strong>Текст:</strong> </span>
               <b-form-input  v-model="addItem.text" style="font-size:15px" required ></b-form-input>
               </div>
           </div>
           <div class="col-md-3 pl-0">
            <span class="d-md-none d-inline-block"> <strong>Изображение:</strong> </span>
              <b-form-file  style="overflow:hidden"
              v-model="addItem.file"
            ></b-form-file>
           </div>
           <div class="col-md-4  pl-0">
             <div>
                <span class="d-md-none   d-inline-block"> <strong>Ссылка:</strong> </span>
               <b-form-input    v-model="addItem.link" style="font-size:15px" required ></b-form-input>
               </div>
           </div>
              <button type="submit" style="position:absolute;top:9px;right:5px;z-index:6" class="btn btn-success">&#10010;</button>
           </form>
           
        </div>









 <div v-for="n in this.$store.state.news" :key="n.id" style="position:relative;overflow: visible">

        <div   class="mymenu2  row m-0 w-100 mt-lg-4 mb-3 p-3 product-item " >
          <div v-if="Edit(n.id)" class="p-0" style="font-size:20px;position:absolute;right:-5px;top:0px; ">
        <b-dropdown size="lg"  class="p-0"   variant="link" toggle-class="text-decoration-none" no-caret>
          <template v-slot:button-content style="color:black;font-size:20px;z-index:5">
            <span style="color:black;font-size:20px;z-index:5"  >⋮</span>
          </template>
          <div style="z-index:6;font-size:12px" >
          <b-dropdown-item  @click="Delete(n.id)" style="z-index:10;font-size:12px" href="#">Удалить</b-dropdown-item>
          <b-dropdown-item  style="z-index:10;font-size:12px" @click="editId= n.id" href="#">Изменить</b-dropdown-item>
          </div>
        </b-dropdown>
      </div>

      <div v-if="!Edit(n.id)" style="font-size:20px;position:absolute;right:5px;top:5px;z-index:100 ">
          <button class="p-0 btn btn-light" @click="SaveEdit(n)" style="font-size:15px;z-index:100">	&#128190;</button>
      </div>


           <div class="col-md-5 pl-0">
              <span class="d-md-none d-inline-block"> <strong>Текст:</strong> </span>
               <b-form-input v-if="!Edit(n.id)" v-model="n.text" style="font-size:15px" required ></b-form-input>
                <span v-if="Edit(n.id)" class="text-right">   {{n.text}}</span>
 
           </div>

           <div class="col-md-3 pl-0">
            <span class="d-md-none d-inline-block"> <strong>Изображение:</strong> </span>
              <b-form-file v-if="!Edit(n.id)" style="overflow:hidden"
              v-model="file"
              :placeholder="n.img"
            ></b-form-file>
            <img v-if="Edit(n.id)" :src="'http://localhost:5555'+n.img" class="mymenu3"  style="width:100px" alt="123">
      
           </div>
           <div class="col-md-4 pl-0">
              <span class="d-md-none  d-inline-block"> <strong>Ссылка:</strong> </span>
               <b-form-input v-if="!Edit(n.id)" v-model="n.link" style="font-size:15px" required ></b-form-input>
                <span v-if="Edit(n.id)" class="text-right">   {{n.link}}</span>
 
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

import swal from 'sweetalert'

const toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});

export default {
  name: "Main",
  components: {
  
  },
  data(){
    return{
     editId:"",
      
        file: null,
        status: 'not_accepted',
        addItem:{
          text:null,
          img:null,
          file:null,
          link:null
        },
        showAdd: false

    }
  },
  async mounted(){

        if(this.$store.state.AllAboutToken && this.$store.state.user['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=='admin'){
        console.log("go")
        await this.$store.dispatch('GetNews')
        }
        else{
            this.$router.push('/')
        }
    
  },
  methods:{
    Delete(id){
       swal({
  title: "Вы действительно хотите удалить эту новость?",
  icon: "warning",
  buttons: true,
  dangerMode: true,
})
.then((willDelete) => {
  if (willDelete) {
     this.$store.dispatch("DeleteNews",id)
    swal("Категория была успешно удалена", {
      icon: "success",
    });
    
  } else {
    swal("Вы сохранили ему жизнь!");
  }
});  
    },
    Edit(id){
        return this.editId == id? false :true
      },
      async SaveEdit(item){
        console.log(item)
        console.log(this.file)
        this.file==null?item.img =null:item.img =  await toBase64(this.file);
        this.$store.dispatch("EditNews",item)
        this.editId = ""
        this.file = null
      },
      async AddCategory(){
        
        this.addItem.img =  await toBase64(this.addItem.file);
        this.$store.dispatch("AddNews",this.addItem)
        console.log(this.addItem)
        this.showAdd =false
      }
     
    
}
  
}
</script>
