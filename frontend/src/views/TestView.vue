<template>
    <HomeBackground>
        <FormButton>
            Авториzация
        </FormButton>
    </HomeBackground>
</template>
  
  
<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/background/HomeBackground.vue"
import FormButton from "@/components/button/FormButton.vue"

export default defineComponent({
setup() {
    // auth.logout()
},
components: {
    HomeBackground,
    FormButton
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