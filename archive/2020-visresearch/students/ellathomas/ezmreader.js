//Reader for Electric Zine Maker by Jeremy Oduber in 2019
// https://twitter.com/JeremyOduber
// https://jeremyoduber.itch.io/
//Electric Zine Maker: https://alienmelon.itch.io/electric-zine-maker

const FOV = 45;
const HEIGHT = 650;
const NEAR = 0.1;
const FAR = 1000;
const VFOV = FOV * (Math.PI / 180);
const PAGEWIDTH = 421;
const PAGEHEIGHT = 595;
const LAYERONE = 0;
const LAYERTWO = -1;
const LAYERTHREE = -2;
const LAYERFOUR = -3;
const manager = new THREE.LoadingManager();
const loader = new THREE.TextureLoader(manager);
const loadingOverlay = document.querySelector('#loading')

var mouse = new THREE.Vector2;
var allowInput = true;
var currentState = 0;

//init start
var renderer = new THREE.WebGLRenderer({antialias: true});
renderer.setSize(window.innerWidth, window.innerHeight)
renderer.setClearColor(000000); //change this to set background color
document.body.appendChild(renderer.domElement);
var scene = new THREE.Scene();
var camera = new THREE.PerspectiveCamera(FOV, window.innerWidth/window.innerHeight, 0.1, 1000);
camera.position.z = HEIGHT / (2* Math.tan(VFOV / 2) );
camera.lookAt(scene.position);
window.addEventListener('resize', function()
{
    renderer.setSize(window.innerWidth, window.innerHeight);
    camera.aspect = window.innerWidth/window.innerHeight;
    camera.updateProjectionMatrix();
});
//init done

manager.onLoad = function () {
    loadingOverlay.classList.add('loading-hidden');
};


//make pages
//card one
var pageOneG = new THREE.PlaneGeometry(PAGEWIDTH, PAGEHEIGHT, 1, 1);
var pageTwoG = new THREE.PlaneGeometry(PAGEWIDTH, PAGEHEIGHT, 1, 1);
pageTwoG.applyMatrix(new THREE.Matrix4().makeRotationY(Math.PI));
var pageOneT = loader.load('FRONT.png');
pageOneT.minFilter = THREE.LinearFilter;
var pageTwoT = loader.load('INNERFRONT.png');
pageTwoT.minFilter = THREE.LinearFilter;
var pageOneM = new THREE.MeshBasicMaterial( { map: pageOneT});
var pageTwoM = new THREE.MeshBasicMaterial({ map: pageTwoT});
var pageOneMesh = new THREE.Mesh(pageOneG, pageOneM);
pageOneMesh.position.x = PAGEWIDTH / 2;
var pageTwoMesh = new THREE.Mesh(pageTwoG, pageTwoM);
pageTwoMesh.position.x = PAGEWIDTH /2 ;
cardOne = new THREE.Object3D();
cardOne.position.z = LAYERONE;
//card two
var pageThreeG = new THREE.PlaneGeometry(PAGEWIDTH, PAGEHEIGHT, 1, 1);
var pageFourG = new THREE.PlaneGeometry(PAGEWIDTH, PAGEHEIGHT, 1, 1);
pageFourG.applyMatrix(new THREE.Matrix4().makeRotationY(Math.PI));
var pageThreeT = loader.load('1.png');
pageThreeT.minFilter = THREE.LinearFilter;
var pageFourT = loader.load('2.png');
pageFourT.minFilter = THREE.LinearFilter;
var pageThreeM = new THREE.MeshBasicMaterial( { map: pageThreeT});
var pageFourM = new THREE.MeshBasicMaterial({ map: pageFourT});
var pageThreeMesh = new THREE.Mesh(pageThreeG, pageThreeM);
pageThreeMesh.position.x = PAGEWIDTH / 2;
var pageFourMesh = new THREE.Mesh(pageFourG, pageFourM);
pageFourMesh.position.x = PAGEWIDTH /2 ;
cardTwo = new THREE.Object3D();
cardTwo.position.z = LAYERTWO;
//card three
var pageFiveG = new THREE.PlaneGeometry(PAGEWIDTH, PAGEHEIGHT, 1, 1);
var pageSixG = new THREE.PlaneGeometry(PAGEWIDTH, PAGEHEIGHT, 1, 1);
pageSixG.applyMatrix(new THREE.Matrix4().makeRotationY(Math.PI));
var pageFiveT = loader.load('3.png');
pageFiveT.minFilter = THREE.LinearFilter;
var pageSixT = loader.load('4.png');
pageSixT.minFilter = THREE.LinearFilter;
var pageFiveM = new THREE.MeshBasicMaterial( { map: pageFiveT});
var pageSixM = new THREE.MeshBasicMaterial({ map: pageSixT});
var pageFiveMesh = new THREE.Mesh(pageFiveG, pageFiveM);
pageFiveMesh.position.x = PAGEWIDTH / 2;
var pageSixMesh = new THREE.Mesh(pageSixG, pageSixM);
pageSixMesh.position.x = PAGEWIDTH /2 ;
cardThree = new THREE.Object3D();
cardThree.position.z = LAYERTHREE;
//card four
var pageSevenG = new THREE.PlaneGeometry(PAGEWIDTH, PAGEHEIGHT, 1, 1);
var pageEightG = new THREE.PlaneGeometry(PAGEWIDTH, PAGEHEIGHT, 1, 1);
pageEightG.applyMatrix(new THREE.Matrix4().makeRotationY(Math.PI));
var pageSevenT = loader.load('5.png');
pageSevenT.minFilter = THREE.LinearFilter;
var pageEightT = loader.load('BACK.png');
pageEightT.minFilter = THREE.LinearFilter;
var pageSevenM = new THREE.MeshBasicMaterial( { map: pageSevenT});
var pageEightM = new THREE.MeshBasicMaterial({ map: pageEightT});
var pageSevenMesh = new THREE.Mesh(pageSevenG, pageSevenM);
pageSevenMesh.position.x = PAGEWIDTH / 2;
var pageEightMesh = new THREE.Mesh(pageEightG, pageEightM);
pageEightMesh.position.x = PAGEWIDTH /2 ;
cardFour = new THREE.Object3D();
cardFour.position.z = LAYERFOUR;
//cards done
//turn areas
var turnG = new THREE.PlaneGeometry(PAGEWIDTH/2, PAGEHEIGHT, 1, 1);
var turnM = new THREE.MeshBasicMaterial({color: 0xf8f800});
turnM.transparent = true;
turnM.opacity = 0;
var turnRightMesh = new THREE.Mesh(turnG, turnM);
turnRightMesh.position.x = (PAGEWIDTH / 4) * 3;
turnRightMesh.position.z = 1;
var turnLeftMesh = new THREE.Mesh(turnG, turnM);
turnLeftMesh.position.x = -(PAGEWIDTH / 4) * 3;
turnLeftMesh.position.z = 1;

//adding stuff
cardOne.add(pageOneMesh);
cardOne.add(pageTwoMesh);
cardTwo.add(pageThreeMesh);
cardTwo.add(pageFourMesh);
cardThree.add(pageFiveMesh);
cardThree.add(pageSixMesh);
cardFour.add(pageSevenMesh);
cardFour.add(pageEightMesh);

scene.add(cardOne);
scene.add(cardTwo);
scene.add(cardThree);
scene.add(cardFour);
scene.add(turnRightMesh);
scene.add(turnLeftMesh);
//stuff added

//setup tweens
var cardOneTween = TweenMax.to(cardOne.rotation, .8, {y: 0 - Math.PI, ease: Power2.easeInOut, paused: true, onComplete: oneComplete, onReverseComplete: genericComplete});
var cardTwoTween = TweenMax.to(cardTwo.rotation, .8, {y: 0 - Math.PI, ease: Power2.easeInOut, paused: true, onComplete: twoComplete, onReverseComplete: genericComplete});
var cardThreeTween = TweenMax.to(cardThree.rotation, .8, {y: 0 - Math.PI, ease: Power2.easeInOut, paused: true, onComplete: genericComplete, onReverseComplete: threeReverseComplete});
var cardFourTween = TweenMax.to(cardFour.rotation, .8, {y: 0 - Math.PI, ease: Power2.easeInOut, paused: true, onComplete: genericComplete, onReverseComplete: fourReverseComplete});

function animate(){
    requestAnimationFrame(animate);
    renderer.render(scene, camera);
}

document.addEventListener('keyup', keyInput);

function keyInput(key){

    if (allowInput == true ){
        if (key.keyCode === 65 || key.keyCode === 37){
            leftTurn();
        }
        if (key.keyCode === 68 || key.keyCode === 39){
            rightTurn();
        }
    }
}

var raycaster = new THREE.Raycaster();
document.addEventListener("mouseup", raycast, false);

function raycast(event){

   if (allowInput == true){

        mouse.x = (event.clientX / window.innerWidth ) * 2 - 1;
        mouse.y = - ( event.clientY / window.innerHeight ) * 2 + 1;

        raycaster.setFromCamera(mouse, camera);

        var intersects = raycaster.intersectObjects( scene.children );

	    for ( var i = 0; i < intersects.length; i++ ) {

            var intersected = intersects[0].object

            if (intersected == turnLeftMesh){
                rightTurn();
            } else if (intersected == turnRightMesh){
                leftTurn();
            }
        }
    }
}

function leftTurn(){

    switch(currentState){
        case 0:
            allowInput = false;
            cardOneTween.play();
            currentState = 1;
            break;
        case 1:
            allowInput = false;
            cardTwoTween.play();
            currentState = 2;
            break;
        case 2:
            allowInput = false;
            cardThreeTween.play();
            currentState = 3;
            cardThree.position.z = LAYERTWO;
            break;
        case 3:
            allowInput = false;
            cardFourTween.play();
            currentState = 4;
            cardFour.position.z = LAYERONE;
            break;
        case 4:
            //do nothing
            break;
    }
}

function rightTurn(){

    switch(currentState){
        case 0:
            //do nothing
            break;
        case 1:
            allowInput = false;
            cardOneTween.reverse();
            currentState = 0;
            cardOne.position.z = LAYERONE;
            break;
        case 2:
            allowInput = false;
            cardTwoTween.reverse();
            currentState = 1;
            cardTwo.position.z = LAYERTWO;
            break;
        case 3:
            allowInput = false;
            cardThreeTween.reverse();
            currentState = 2;
            break;
        case 4:
            allowInput = false;
            cardFourTween.reverse();
            currentState = 3;
            break;
    }
}

function genericComplete(){
    allowInput = true;
}

function oneComplete(){
    allowInput = true;
    cardOne.position.z = LAYERFOUR;
}

function twoComplete(){
    allowInput = true;
    cardTwo.position.z = LAYERTHREE;
}

function threeReverseComplete(){
    allowInput = true;
    cardThree.position.z = LAYERTHREE;
}

function fourReverseComplete(){
    allowInput = true;
    cardFour.position.z = LAYERFOUR;
}

animate();
