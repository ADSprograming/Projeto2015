var app = angular.module('petSpa', [])
    app.controller('PetSpaController', ['$scope', '$http', function ($scope, $http){
        $scope.slides = [
            {image: 'img/cat-and-dog_thumb.jpg',descricao:'imagem1'},
            {image: 'img/petshop.jpg',descricao:'imagem2'},
            {image: 'img/petspa-doral-fl.jpg',descricao:'imgame3'},
            {image: 'img/animais05_800.jpg',descricao:'image4'},
	    {image: 'img/pet-sitting-pg.jpg',descricao:'image5'},
        ];
   
        $scope.direction = 'left';
        $scope.currentIndex = 0;

        $scope.setCurrentSlideIndex = function (index) {
            $scope.direction = (index > $scope.currentIndex) ? 'left' : 'right';
            $scope.currentIndex = index;
        };

        $scope.isCurrentSlideIndex = function (index) {
            return $scope.currentIndex === index;
        };

        $scope.prevSlide = function () {
            $scope.direction = 'left';
            $scope.currentIndex = ($scope.currentIndex < $scope.slides.length - 1) ? ++$scope.currentIndex : 0;
        };

        $scope.nextSlide = function () {
            $scope.direction = 'right';
            $scope.currentIndex = ($scope.currentIndex > 0) ? --$scope.currentIndex : $scope.slides.length - 1;
        };

        
        $scope.cliente = [
        {nome:"sostenes",cpf:"00903380195",telefone:"993849500"}
        ];
    
        
        $scope.submitForm = function(isValid) {
         if(isValid){
            alert('Formulario ok');
        }
    };
        
        $scope.buscar = function(cep){
        $http.get('https://viacep.com.br/ws/'+ cep +'/json/').success(function(local){
            $scope.endereco = local;
    });
        }
        

}]);
