<template>
  <notifications position="top center" classes="notify" width="20%" />
  <router-view/>
</template>


<style>
@font-face {
  font-family: "Frenchpress";
  src: local("Frenchpress"),
   url(./assets/fonts/Frenchpress.otf) format("truetype");
}

#app {
  font-family: "Frenchpress";
}

.notify {
  font-size: 28px;
  background: var(--white) !important;
  margin: 0 5px 5px;
  padding: 10px;
  border-left: 15px solid var(--pink);
  color: var(--gray);
  text-shadow: 0px 0px 20px var(--wite);
}

:root {
  --tiny-text: 24px;
  --little-text: 32px;
  --middle-text: 48px;
  --large-text: 60px;
  --huge-text: 96px;

  --green-color: #465F5A;
  --emerald-color: #225721;
  --beige-color: #F8EFE5;
  --wine-color: #A12626;

  --font-name: "Frenchpress";
}
</style>
