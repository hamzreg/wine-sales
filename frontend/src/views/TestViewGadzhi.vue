<template>
  <HomeBackground>
      <InputLine placeholderText="qweqwewqeqwe">
      </InputLine>
  </HomeBackground>
</template>


<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/background/HomeBackground.vue"
import InputLine from "@/components/InputLine.vue"

export default defineComponent({
setup() {
  // auth.logout()
},
components: {
  HomeBackground,
  InputLine,
},
});
</script>


<style scoped>
.logo {
position: absolute;
left: 35%;
bottom: 0%;
}
</style>