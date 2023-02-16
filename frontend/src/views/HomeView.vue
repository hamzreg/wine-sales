<template>
  <div class="bg">
  <div class="home">
    <img src="../assets/img/logo.png" height="100"/>
  </div>
</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Text from "@/views/Text.vue"

export default defineComponent({
  name: 'HomeView',
  // components: {
  //   Text,
  // },
});
</script>

<style scoped>
.bg {
  /* display: flex;
  flex-direction: column;
  margin: 0;
  width: 90%;
  height: 100%;
  justify-content: center;
  align-items: center;
  gap: 10px; */
  background-color: #465F5A;
  background-image: url("@/assets/img/logo.png");
}
</style>
