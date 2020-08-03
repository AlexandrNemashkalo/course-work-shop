<template>
 <hooper   :itemsToShow="3" :wheelControl="false" id="botCar"  style="height:100%; " >








  <slide v-for="news in this.$store.state.news" :key="news.id" class="p-1  thumbs">
    <span style="position:absolute;color:white"></span>
    <img :src="'http://localhost:5555'+ news.img"  style="width:100%;border-radius:10px" alt="">
     <div class="caption">
          <span class="title mb-4"><a class="btn btn-warning" target="_blank" :href="news.link" style="font-size:15px;color: white"> <strong>ПЕРЕЙТИ</strong> </a></span>

        <span class="title">{{news.text}} </span>
      
    </div>
  </slide>
  

   <hooper-pagination class="d-md-block d-none" slot="hooper-addons"></hooper-pagination>
   <hooper-navigation2 class="d-md-block d-none" slot="hooper-addons"></hooper-navigation2>
 </hooper>
</template>

<script>
import {
  Hooper,
  Slide,
  Pagination  as HooperPagination,
  Navigation as HooperNavigation2
  } from 'hooper';


export default {
  name: 'mini3',
    components: {
    Hooper,
    Slide,
    HooperPagination,
    HooperNavigation2
  }
};
</script>
<style >
.thumbs {
  opacity: .99;
  overflow: hidden;
  position: relative;
  border-radius: 3px;
  cursor: pointer;
 
}
.thumbs:before {
  content: '';
  background: -webkit-linear-gradient(top, transparent 0%, rgba(126, 91, 91, 0.9) 100%);
  background: linear-gradient(to bottom, transparent 0%, rgba(0, 0, 0, 1) 100%);
  width: 100%;
  height: 50%;
  opacity: 0;
  position: absolute;
  top: 100%;
  left: 0;
  z-index: 2;
  -webkit-transition-property: top, opacity;
  transition-property: top, opacity;
  -webkit-transition-duration: 0.3s;
  transition-duration: 0.3s;
}
.thumbs img {
  display: block;
  width: 100%; /* ширина картинки */
  height: auto; /* высота картинки */
  backface-visibility: hidden;
  -webkit-backface-visibility: hidden;
}
.thumbs .caption {
  width: 100%;
  padding: 20px;
  color: #fff;
  position: absolute;
  bottom: 0;
  left: 0;
  z-index: 3;
  text-align: center;
}
.thumbs .caption span {
  display: block;
  opacity: 0;
  position: relative;
  top: 100px;
  -webkit-transition-property: top, opacity;
  transition-property: top, opacity;
  -webkit-transition-duration: 0.3s;
  transition-duration: 0.3s;
  -webkit-transition-delay: 0s;
  transition-delay: 0s;
}
.thumbs .caption .title {
  line-height: 1;
  font-weight: normal;
  font-size: 18px;
}
.thumbs .caption .info {
  line-height: 1.2;
  margin-top: 5px;
  font-size: 12px;
}
.thumbs:focus:before,
.thumbs:focus span, .thumbs:hover:before,
.thumbs:hover span {
  opacity: 1;
}
.thumbs:focus:before, .thumbs:hover:before {
  top: 50%;
}
.thumbs:focus span, .thumbs:hover span {
  top: 0;
}
.thumbs:focus .title, .thumbs:hover .title {
  -webkit-transition-delay: 0.15s;
          transition-delay: 0.15s;
}
.thumbs:focus .info, .thumbs:hover .info {
  -webkit-transition-delay: 0.25s;
          transition-delay: 0.25s;
}
</style>