<template>
    <HomeBackground>
        <HomeButton>
        </HomeButton>
    </HomeBackground>
</template>
  
  
<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/HomeBackground.vue"
import HomeButton from "@/components/HomeButton.vue"

export default defineComponent({
setup() {
    // auth.logout()
},
components: {
    HomeBackground,
    HomeButton
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