#include <AccelStepper.h>
#include <MCP3017AccelStepper.h>

String str = "";
long j2;


//#define STEPPER_SETUP // Раскомментировать для настройки
//#define STEPPER_DEBUG //Раскомментировать для поиска ошибок

#define STEPPER_NUM 1 // Количество шаговых двигателей


MCP3017AccelStepper stepper[STEPPER_NUM] = { // Определение двигателей
  MCP3017AccelStepper (AccelStepper::HALF4WIRE, 14,15,16,17) 
};


const byte stepperOptronPin[STEPPER_NUM] = {18}; // Пины оптронов
String stepperSymbol = "s"; // Обозначение шаговых двигателей
String stepperSymbolB = "r";

#define STEPPER_ACCELERATION 5 // Ускорение //-
#define STEPPER_SPEED 800 // Скорость //-

#define STEPPER_ACCELERATION_yst 400 // Ускорение //-
#define STEPPER_SPEED_yst 200 // Скорость //-

boolean stepperBuzy[STEPPER_NUM] = {false}; // Статус работы

/////////////

boolean stepperZeroSettingLock[STEPPER_NUM] = {false}; // Блокировка движения в конце loop(){}
boolean stepperZeroSettingStepA[STEPPER_NUM] = {false}; // Логические шаги установки нуля
boolean stepperZeroSettingStepB[STEPPER_NUM] = {false};
boolean stepperZeroSettingStepC[STEPPER_NUM] = {false};
boolean stepperZeroSettingStepD[STEPPER_NUM] = {false};
boolean stepperZeroSettingStepE[STEPPER_NUM] = {false};

unsigned long stepperZeroSettingTimeC[STEPPER_NUM] = {0}; // Измерение времени в логическом шаге
unsigned long stepperZeroSettingTimeD[STEPPER_NUM] = {0};

#define STEPPER_ZERO_SETTING_SPEED_B 100 // Скорость, выставляемая в логическом шаге
#define STEPPER_ZERO_SETTING_DEAD_TIME_C 50 // Время ожидания перед шагом
#define STEPPER_ZERO_SETTING_DEAD_TIME_D 50

long stepperZeroPos[STEPPER_NUM] = {0}; // Положение нуля

/////////////

#ifndef STEPPER_SETUP
  boolean stepperZeroSettingStepF[STEPPER_NUM] = {false};
  // Дополнительные логические шаги установки нуля
  boolean stepperMoveStepA[STEPPER_NUM] = {false}; // Логические шаги сдвига
  boolean stepperMoveStepB[STEPPER_NUM] = {false};

  long stepperTrueZeroPos[STEPPER_NUM] = {362}; // Положение нуля шкалы
  long stepperBorder[STEPPER_NUM][2] = {{0, 1000}}; // Границы шкалы
  long stepperPos[STEPPER_NUM] = {0};  // Текущее положение
#endif

//////////////

#ifdef STEPPER_DEBUG
  long stepperDebugPos[STEPPER_NUM] = {0};
#endif
#define ENC10BIT_DEC // Вывод в десятичной системе
const byte enc10bitPin[10] = {52,50,48,46,44,42,40,38,36,34}; // Пины 35, 37, 39, 41, 43, 45, 47, 49, 51, 53  52, 50, 48, 46, 44, 42, 40, 38, 36, 34
boolean enc10bitBinaryPos[10]; // Положение в двоичной системе
boolean enc10bitOldBinaryPos[10]; // Предыдущее оложение в двоичной системе
boolean enc10bitPrint; // Необходимость выдать положение

boolean enc10bitPrintNew; // Необходимость выдать положение
int enc10bitLEFT = 773; 
int enc10bitdontNULL = 20; 
int enc10bitdontNULLmap = 15; 
boolean enc10bitMAP = false; 
#ifdef ENC10BIT_DEC
  unsigned int enc10bitPos; // Положение в десятичной системе системе
  unsigned int enc10bitOldPos; // Предыдущее оложение в двоичной системе
  byte enc10bitZero; // Отметки нуля (выдача, если три подряд)
#endif
boolean print = true;
int k = 0;
String str10Bit = "";
int BitSTR = 0;
int BitSTRnew = 0;
int BitSTRPrint = 0;
int BitSTRPrintRev = 0;
int BitSTRPrintST = 1100;
int BitSTRPrintSTmap = 1100;
unsigned int enc10bittoggleDelay = 50;
unsigned long enc10bittoggleTime = 0.0;
boolean enc10bitReversal = false;


String elemSymbol = "b"; // Обозначение элементов

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО СВЕТОДИОДОВ!
#define DIODNUM 3

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО СВЕТОДИОДОВ!
const byte diodIn[] = {2,3,4}; // Пины светодиодов
bool diodLog[] = {false, false, false}; // Переменная для определения изменений в положении светодиодов



#define ELEM_NUM 3 // Количество элементов

int i,n = 0;

const byte elemPin[ELEM_NUM] = {6,8,7}; // Пины элементов

boolean elemPos[ELEM_NUM] = {false, false}; // Положение
boolean elemRev[ELEM_NUM] = {false, false}; // Реверс

unsigned int elemDelay[ELEM_NUM] = {50, 1500, 1500}; // Время между двумя изменениями положения

unsigned long elemTime[ELEM_NUM] = {0, 0, 0};
// Момент времени изменения положения



// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
#define TOGGNUM 1

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
const byte toggIn1[] = {9}; // Пины тумблеров поз.1
bool toggLog1[] = {false}; // Переменная для определения изменений в положении тумблера

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ТУМБЛЕРОВ!
const byte toggIn2[] = {5}; // Пины тумблеров поз.2
bool toggLog2[] = {false}; // Переменная для определения изменений в положении тумблера






#define ENC10BIT_DEC4 // Вывод в десятичной системе
const byte enc10bitPin4[10] = {A2,A3,A4,A5,A6,A7,A8,A9,A10,A11}; // Пины 35, 37, 39, 41, 43, 45, 47, 49, 51, 53  52, 50, 48, 46, 44, 42, 40, 38, 36, 34
boolean enc10bitBinaryPos4[10]; // Положение в двоичной системе
boolean enc10bitOldBinaryPos4[10]; // Предыдущее оложение в двоичной системе
boolean enc10bitPrint34; // Необходимость выдать положение

boolean enc10bitPrint34New3; // Необходимость выдать положение
int enc10bitLEFT34 = 913; 
int enc10bitdontNULL34 = 20; 
int enc10bitdontNULL34map3 = 15; 
boolean enc10bitMAP34 = false; 
#ifdef ENC10BIT_DEC4
  unsigned int enc10bitPos345; // Положение в десятичной системе системе
  unsigned int enc10bitOldPos35; // Предыдущее оложение в двоичной системе
  byte enc10bitZero34; // Отметки нуля (выдача, если три подряд)
#endif


String str10Bit34 = "";
int BitSTR35 = 0;
int BitSTR35new3 = 0;
int BitSTR35Print3 = 0;
int BitSTR35Print3Rev3 = 0;
int BitSTR35Print3ST3 = 1100;
int BitSTR35Print3ST3map3 = 1100;
unsigned int enc10bittoggleDelay35 = 50;
unsigned long enc10bittoggleTime34 = 0.0;
boolean enc10bitReversal354 = false;



#define ENC10BIT_DEC3 // Вывод в десятичной системе
const byte enc10bitPin3[10] = {31,30,29,28,27,26,25,24,23,22}; // Пины 35, 37, 39, 41, 43, 45, 47, 49, 51, 53  52, 50, 48, 46, 44, 42, 40, 38, 36, 34
boolean enc10bitBinaryPos3[10]; // Положение в двоичной системе
boolean enc10bitOldBinaryPos3[10]; // Предыдущее оложение в двоичной системе
boolean enc10bitPrint3; // Необходимость выдать положение

boolean enc10bitPrint3New3; // Необходимость выдать положение
int enc10bitLEFT3 = 575; 
int enc10bitdontNULL3 = 15; 
int enc10bitdontNULL3map3 = 15; 
boolean enc10bitMAP3 = false; 
#ifdef ENC10BIT_DEC3
  unsigned int enc10bitPos3; // Положение в десятичной системе системе
  unsigned int enc10bitOldPos3; // Предыдущее оложение в двоичной системе
  byte enc10bitZero3; // Отметки нуля (выдача, если три подряд)
#endif


String str10Bit3 = "";
int BitSTR3 = 0;
int BitSTR3new3 = 0;
int BitSTR3Print3 = 0;
int BitSTR3Print3Rev3 = 0;
int BitSTR3Print3ST3 = 1100;
int BitSTR3Print3ST3map3 = 1100;
unsigned int enc10bittoggleDelay3 = 50;
unsigned long enc10bittoggleTime3 = 0.0;
boolean enc10bitReversal3 = false;


#define ENC10BIT_DEC2 // Вывод в десятичной системе
const byte enc10bitPin2[10] = {53,51,49,47,45,43,41,39,37,35}; // Пины 35, 37, 39, 41, 43, 45, 47, 49, 51, 53  52, 50, 48, 46, 44, 42, 40, 38, 36, 34
boolean enc10bitBinaryPos2[10]; // Положение в двоичной системе
boolean enc10bitOldBinaryPos2[10]; // Предыдущее оложение в двоичной системе
boolean enc10bitPrint2; // Необходимость выдать положение

boolean enc10bitPrint2New2; // Необходимость выдать положение
int enc10bitLEFT2 = 655; 
int enc10bitdontNULL2 = 15; 
int enc10bitdontNULL2map2 = 15; 
boolean enc10bitMAP2 = false; 
#ifdef ENC10BIT_DEC2
  unsigned int enc10bitPos2; // Положение в десятичной системе системе
  unsigned int enc10bitOldPos2; // Предыдущее оложение в двоичной системе
  byte enc10bitZero2; // Отметки нуля (выдача, если три подряд)
#endif


String str10Bit2 = "";
int BitSTR2 = 0;
int BitSTR2new2 = 0;
int BitSTR2Print2 = 0;
int BitSTR2Print2Rev2 = 0;
int BitSTR2Print2ST2 = 1100;
int BitSTR2Print2ST2map2 = 1100;
unsigned int enc10bittoggleDelay2 = 50;
unsigned long enc10bittoggleTime2 = 0.0;
boolean enc10bitReversal2 = false;


////                                                                            ////
//        ПЕРЕМЕННЫЕ РАЗЪЕМОВ 2    - new                                            //
////                                                                            ////

//#define razSetup

#define razERROR 20 // Шум в значении потенциометра

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ 2!
#define razNUM 2

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО РАЗЪЕМОВ 2!
const byte razPin[razNUM] = {0, 1}; // Пины РАЗЪЕМОВ 2 {0, 1, 2}

int razPos[razNUM] = {0, 0}; // Положение потенциометра

int oldrazPos[razNUM] = {0, 0}; // Предыдущее положение потенциометра
int razType[razNUM] = {0, 0}; // Тип потенциометра
int razBorder[razNUM][2] = {{0, 1000}, {0, 1000}};

int razAnswer[razNUM] = {480,440};

#define razERRORAnswer 15

// Границы значений потенциометра

double truerazPos[razNUM] = {0, 0}; // Положение потенциометра по шкале
double oldTruerazPos[razNUM] = {0, 0}; // Старое положение потенциометра по шкале

int truerazAnswer[razNUM] = {0, 0}; // Положение потенциометра по шкале
int oldTruerazAnswer[razNUM] = {2, 2}; // Старое положение потенциометра по шкале

unsigned long razTime[razNUM] = {0, 0}; // Момент времени изменения положения кнопки

#define razDELAY 1500 // Время между двумя изменениями
#define razDELAYsetup 20 // Время между двумя изменениями


unsigned long traz = 0;


#include <ACE128.h>
#include <ACE128map87654321.h> // Карта пинов 87654321






//#define ENCSETUP // Раскомментировать для настройки
//#define ENCODERSETUP

#define ENCNUM 2 // Количество энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
const byte encoderAddress[ENCNUM]= {32,33}; // Адреса энкодеров

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
ACE128 enc0((uint8_t)encoderAddress[0], (uint8_t*)encoderMap_87654321); // Адрес и карта энкодера
ACE128 enc1((uint8_t)encoderAddress[1], (uint8_t*)encoderMap_87654321);





uint8_t rawPos[ENCNUM] = {0,0}; // Текущее положение энкодера
uint8_t oldRawPos[ENCNUM] = {127,127}; // Предыдущее положение энкодера

#ifndef ENCSETUP
  int encType[ENCNUM] = {0,4}; // Тип энкодера !!!  0 - приведение к границам, 1 - границы и круговой, 4 - круговой (0.00 - 1.00)
  int rawBorder[ENCNUM][2] = {{124, 102},{27, 27}};
  // Границы положений энкодера
  int encBorder[ENCNUM][2] = {{0, 5},{0, 24}};
  // Границы положений энкодера по шкале
  
  double encPoint[ENCNUM] = {0,0}; // Средняя точка
  double encPos[ENCNUM] = {0,0}; // Положение энкодера по шкале
  double oldEncPos[ENCNUM] = {0,0}; // Предыдущее положение энкодера по шкале
  double rawNorm[ENCNUM] = {0,0}; // Норма
#endif




void setup() {
  // put your setup code here, to run once:
  
  Serial.begin(115200); // Инициализация порта для работы с ПК
  Serial.println("PVD");
  Serial.println("complite");

   #ifdef STEPPER_SETUP
    Serial.println("STEPPER SETUP DEFINED");
  #endif

  #ifdef STEPPER_DEBUG
    Serial.println("STEPPER DEBUG DEFINED");
  #endif

  #ifndef STEPPER_SETUP
    for(i = 0; i < STEPPER_NUM; i++){ // Включение установки нуля
      stepperZeroSettingStepA[i] = true;
    }
  #endif



  for(i = 0; i < STEPPER_NUM; i++){ // Настройка двигателей


pinMode(stepperOptronPin[i], INPUT);
    
  }

  for(i = 0; i < STEPPER_NUM; i++){ // Настройка двигателей
    stepper[i].setMaxSpeed(STEPPER_SPEED);
    stepper[i].setSpeed(STEPPER_SPEED);
    stepper[i].setAcceleration(STEPPER_ACCELERATION);
  }
 for(int i = 0; i < DIODNUM; i++){
    pinMode(diodIn[i], OUTPUT); // Настройка пина на выход
    digitalWrite(diodIn[i], LOW); // Выключение светодиодов
  }

  for(i = 0; i < ELEM_NUM; i++){ // Настройка пинов
    pinMode(elemPin[i], INPUT_PULLUP); 
  }

  for(i = 0; i < ELEM_NUM; i++){ // Опрос
    if(elemRev[i] == false){
      if(digitalRead(elemPin[i]) == HIGH){
       
        Serial.print(elemSymbol);
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");
        Serial.println("0");
      }
      else if(digitalRead(elemPin[i]) == LOW){
        
        Serial.print(elemSymbol);
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");
        Serial.println("1");
        elemPos[i] = true;      
      } 
    }
    else{
      if(digitalRead(elemPin[i]) == HIGH){
        
        Serial.print(elemSymbol);
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");
        Serial.println("0");
        elemPos[i] = true;
      }
      else if(digitalRead(elemPin[i]) == LOW){
        
        Serial.print(elemSymbol);
        Serial.print("#");
        Serial.print(i);
        Serial.print("#");
        Serial.println("1");
      } 
    }
    n++;
    elemTime[i] = millis();
  }

 for(int i = 0; i < TOGGNUM; i++){
    pinMode(toggIn1[i], INPUT); // Настройка пина на вход
    digitalWrite(toggIn1[i], HIGH); // Подтяжка пина к питанию
    
    pinMode(toggIn2[i], INPUT);
    digitalWrite(toggIn2[i], HIGH);
  }

 for(int i = 0; i < TOGGNUM; i++){ // Опрос тумблеров
    if(digitalRead(toggIn1[i]) == HIGH && digitalRead(toggIn2[i]) == HIGH){
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#"); 
      Serial.println("0");
    }
    else if(digitalRead(toggIn1[i]) == LOW){
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      toggLog1[i] = true;      
    }
    else if(digitalRead(toggIn2[i]) == LOW){
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("2");
      toggLog2[i] = true;        
    }
  }
  

    for(i = 0; i < 10; i++){
    pinMode(enc10bitPin4[i], INPUT);
    enc10bitBinaryPos4[i] = digitalRead(enc10bitPin4[i]);
    enc10bitOldBinaryPos4[i] = enc10bitBinaryPos4[i];
  }
  #ifdef ENC10BIT_DEC4
    k = 2;
    enc10bitPos345 += enc10bitBinaryPos4[0];
    for(i = 1; i < 10; i++){
      enc10bitPos345 += enc10bitBinaryPos4[i] * k;
      k *= 2; 
    }
    enc10bitOldPos35 = enc10bitPos345;
    enc10bitZero34 = 0;
  #endif
  enc10bitPrint34 = true;


    for(i = 0; i < 10; i++){
    pinMode(enc10bitPin3[i], INPUT);
    enc10bitBinaryPos3[i] = digitalRead(enc10bitPin3[i]);
    enc10bitOldBinaryPos3[i] = enc10bitBinaryPos3[i];
  }
  #ifdef ENC10BIT_DEC3
    k = 2;
    enc10bitPos3 += enc10bitBinaryPos3[0];
    for(i = 1; i < 10; i++){
      enc10bitPos3 += enc10bitBinaryPos3[i] * k;
      k *= 2; 
    }
    enc10bitOldPos3 = enc10bitPos3;
    enc10bitZero3 = 0;
  #endif
  enc10bitPrint3 = true;



    for(i = 0; i < 10; i++){
    pinMode(enc10bitPin2[i], INPUT);
    enc10bitBinaryPos2[i] = digitalRead(enc10bitPin2[i]);
    enc10bitOldBinaryPos2[i] = enc10bitBinaryPos2[i];
  }
  #ifdef ENC10BIT_DEC2
    k = 2;
    enc10bitPos2 += enc10bitBinaryPos2[0];
    for(i = 1; i < 10; i++){
      enc10bitPos2 += enc10bitBinaryPos2[i] * k;
      k *= 2; 
    }
    enc10bitOldPos2 = enc10bitPos2;
    enc10bitZero2 = 0;
  #endif
  enc10bitPrint2 = true;

    for(i = 0; i < 10; i++){
    pinMode(enc10bitPin[i], INPUT);
    enc10bitBinaryPos[i] = digitalRead(enc10bitPin[i]);
    enc10bitOldBinaryPos[i] = enc10bitBinaryPos[i];
  }
  #ifdef ENC10BIT_DEC
    k = 2;
    enc10bitPos += enc10bitBinaryPos[0];
    for(i = 1; i < 10; i++){
      enc10bitPos += enc10bitBinaryPos[i] * k;
      k *= 2; 
    }
    enc10bitOldPos = enc10bitPos;
    enc10bitZero = 0;
  #endif
  enc10bitPrint = true;




//////////////НАСТРОЙКИ РАЗЪЕМОВ 2///////////////////

  for (i = 0; i < razNUM; i++) { // Опрос РАЗЪЕМОВ 2
    razPos[i] = analogRead(razPin[i]);
    oldrazPos[i] = razPos[i];
    truerazPos[i] = razPos[i];
    if (truerazPos[i] > razBorder[i][1]) {
      truerazPos[i] = razBorder[i][1];
    }
    else if (truerazPos[i] < razBorder[i][0]) {
      truerazPos[i] = razBorder[i][0];
    }
    truerazPos[i] = (truerazPos[i] - razBorder[i][0]) / (razBorder[i][1] - razBorder[i][0]) * 1000;
    truerazPos[i] = (int)round(truerazPos[i]) / razERROR * razERROR;

    oldTruerazPos[i] = truerazPos[i];


#ifndef razSetup
    if (razAnswer[i] >= truerazPos[i] - razERRORAnswer && razAnswer[i] <= truerazPos[i] + razERRORAnswer)
    {
      //if (razAnswer[i] == truerazPos[i]) {
      Serial.print("c");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");


      Serial.println("1");

      truerazAnswer[i] = 1;
    } else {
      Serial.print("c");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");


      Serial.println("0");

    }
    oldTruerazAnswer[i] = truerazAnswer[i];
#else

    Serial.print("c");
    Serial.print("#");
    Serial.print(i);
    Serial.print("#");
    Serial.println(truerazPos[i]);


#endif


  }




#ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED");
  #endif
  
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  enc0.begin(); // Инициализация работы энкодера
  enc1.begin(); // Инициализация работы энкодера

 
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos(); // Опрос энкодера
  rawPos[1] = enc1.rawPos(); // Опрос энкодера

  
  #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод текущего положения энкодера
      oldRawPos[i] = rawPos[i];
      Serial.print("e");
      Serial.print(i);
      Serial.print(" ");
      Serial.println(rawPos[i]);
    }
  
  #endif

    #ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED 2");
  #endif

  #ifndef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод в порт ПК текущего состояния энкодера
      oldRawPos[i] = rawPos[i];
      if(rawPos[i] == 255){
        #ifdef DEBUG
          Serial.print("e");
          Serial.print(i);
          Serial.print(" ");
          Serial.println("ERROR");
        #endif
        encPos[i] = encBorder[i][0];
      }
      else{
        if (rawBorder[i][0] < rawBorder[i][1]){
          rawNorm[i] = rawBorder[i][1] - rawBorder[i][0];
          encPoint[i] = (rawBorder[i][0] + 128 - rawBorder[i][1] - 1) / 2.0;
          if(rawBorder[i][0] < encPoint[i]){
            encPoint[i] += rawBorder[i][1];
          }
          else{
            encPoint[i] -= rawBorder[i][0];
          }
          if(encPoint[i] > 0){
            if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if((rawPos[i] < encPoint[i]) && (rawPos[i] >= rawBorder[i][1])){
              encPos[i] = (int)1.00;
            }
            else{
              encPos[i] = (int)0.00;
            }
          }
          else{
            if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])){
              encPos[i] = (int)0.00;
            }
            else{
              encPos[i] = (int)1.00;
            }
          }
        }
        else{
          rawNorm[i] = 128 - rawBorder[i][0] + rawBorder[i][1] + 1;
          encPoint[i] = (rawBorder[i][0] - rawBorder[i][1] - 1) / 2.0;
          encPoint[i] += rawBorder[i][1];
          if(rawPos[i] >= rawBorder[i][0]){
            encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
          }
          else if(rawPos[i] <= rawBorder[i][1]){
            encPos[i] = (rawPos[i] + 128 - rawBorder[i][0]) / rawNorm[i];
          }
          else if(rawPos[i] < encPoint[i]){
            encPos[i] = (int)1.00;
          }
          else{
            encPos[i] = (int)0.00;
          }
        }
  
        if(encType[i] == 0){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
        }
  
        if(encType[i] == 1){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
          if(encPos[i] == encBorder[i][1]){
            encPos[i] = encBorder[i][0];
          }
        }

        if(encType[i] == 2){
          encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0])) * 5.0;
          if(encPos[i] == encBorder[i][1]){
            encPos[i] = encBorder[i][0];
          }
        }

        if(encType[i] == 4){
          encPos[i] = round(encPos[i] * 100);
        }
      }
      oldEncPos[i] = encPos[i];
      Serial.print("e");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println((int)encPos[i]);
      n++;
    }

  #endif


   #ifdef ENCODERSETUP
    Serial.println("ENCODERSETUP DEFINED 3");
  #endif


  
}

void loop() {



   for(i = 0; i < STEPPER_NUM; i++){

    //        УСТАНОВКА НУЛЯ ШАГОВЫХ ДВИГАТЕЛЕЙ                                   //
    
    if(stepperZeroSettingStepA[i] == true){
      if(digitalRead(stepperOptronPin[i]) == LOW){
 ///
       // stepper[i].setMaxSpeed(400); //-
 ///    

      stepper[i].setMaxSpeed(100);
      stepper[i].setSpeed(50);
      stepper[i].setAcceleration(8000);

 
        stepper[i].move(-800);
        stepperZeroSettingStepA[i] = false;
        stepperZeroSettingStepB[i] = true;
        stepperZeroSettingLock[i] = true;
        #ifdef STEPPER_DEBUG
          Serial.println("a-b");
        #endif
      }
      else{
        stepperZeroSettingStepA[i] = false;
        stepperZeroSettingStepC[i] = true;
        #ifdef STEPPER_DEBUG
          Serial.println("a-c");
        #endif
      }
      stepperBuzy[i] = true;
    }

    if(stepperZeroSettingStepB[i] == true){
      if(digitalRead(stepperOptronPin[i]) == LOW){
        stepper[i].run();
      }
      else{
        stepper[i].setMaxSpeed(STEPPER_ZERO_SETTING_SPEED_B);
        stepper[i].moveTo(stepper[i].currentPosition());
        stepperZeroSettingStepB[i] = false;
        stepperZeroSettingStepC[i] = true;
        stepperZeroSettingLock[i] = false;
        stepperZeroSettingTimeC[i] = millis();
        #ifdef STEPPER_DEBUG
          Serial.println("b-c");
        #endif
      }
    }

    if(stepperZeroSettingStepC[i] == true && stepper[i].distanceToGo() == 0
        && (millis() - stepperZeroSettingTimeC[i]) > STEPPER_ZERO_SETTING_DEAD_TIME_C){
      stepper[i].move(1);
      stepperZeroSettingStepC[i] = false;
      stepperZeroSettingStepD[i] = true;
      stepperZeroSettingTimeD[i] = millis();
      #ifdef STEPPER_DEBUG
        Serial.println("c-d");
      #endif    
    }

    if(stepperZeroSettingStepD[i] == true && stepper[i].distanceToGo() == 0
        && (millis() - stepperZeroSettingTimeD[i]) > STEPPER_ZERO_SETTING_DEAD_TIME_D){
      if(digitalRead(stepperOptronPin[i]) == LOW){
        stepper[i].move(-1);
        stepperZeroSettingStepD[i] = false;
        stepperZeroSettingStepE[i] = true;
        #ifdef STEPPER_DEBUG
          Serial.println("d-e");
        #endif
      }
      else{
        stepperZeroSettingStepD[i] = false;
        stepperZeroSettingStepC[i] = true;
        #ifdef STEPPER_DEBUG
          Serial.println("d-c");
        #endif
      }
    }

    if(stepperZeroSettingStepE[i] == true && stepper[i].distanceToGo() == 0){
      
      stepper[i].setMaxSpeed(STEPPER_SPEED);
      stepper[i].setSpeed(STEPPER_SPEED);
      stepper[i].setAcceleration(STEPPER_ACCELERATION);
      
      stepperZeroSettingStepE[i] = false;
      stepperZeroPos[i] = stepper[i].currentPosition();
      #ifdef STEPPER_SETUP
        stepperBuzy[i] = false;
        Serial.print(i);
        Serial.print("*=");
        Serial.print(stepperZeroPos[i]);
        Serial.print(" ");
        Serial.print(i);
        Serial.println("-=0");
      #endif
      #ifndef STEPPER_SETUP
        stepperZeroSettingStepF[i] = true;
        stepper[i].move(stepperTrueZeroPos[i]);
        #ifdef STEPPER_DEBUG
          Serial.println("d-f");
        #endif
      #endif 
    }

    #ifndef STEPPER_SETUP
      if(stepperZeroSettingStepF[i] == true & stepper[i].distanceToGo() == 0){
        stepperZeroSettingStepF[i] = false;
        stepperBuzy[i] = false;
       
      //        Serial.print(arduinoSymbol);
//        Serial.print(stepperSymbol);
//        if(i < 10){
//          Serial.print(0);
//        }
//        Serial.print(i);
//        Serial.print(0);
//        Serial.println(endSymbol);
   if(i == (STEPPER_NUM - 1))
         {
          Serial.println("stop");
          }
        


      }

    //        СДВИГ СТРЕЛКИ ШАГОВЫХ ДВИГАТЕЛЕЙ                                    //

      if(stepperMoveStepA[i] == true && stepperBuzy[i] == false){
        stepper[i].moveTo(stepperZeroPos[i] + stepperTrueZeroPos[i] + stepperPos[i]);
        stepperMoveStepA[i] = false;
    //    stepperMoveStepB[i] = true;
      }

 /*     if(stepperMoveStepB[i] == true && stepper[i].distanceToGo() == 0){
        stepperMoveStepB[i] = false;
        Serial.print(arduinoSymbol);
        Serial.print(stepperSymbol);
        if(i < 10){
          Serial.print(0);
        }
        Serial.print(i);
        Serial.print(stepperPos[i]);
        Serial.println(endSymbol);
      }*/
    #endif  
  }

  // put your main code here, to run repeatedly:
 for(int i = 0; i < TOGGNUM; i++){ // Опрос тумблеров
    if(digitalRead(toggIn1[i]) == LOW && toggLog1[i] == false){
      delay(50);
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("1");
      toggLog1[i] = true;     
    }
    else if(digitalRead(toggIn2[i]) == LOW && toggLog2[i] == false){
      delay(50);
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("2");
      toggLog2[i] = true;      
    }
    else if((digitalRead(toggIn1[i]) == HIGH && toggLog1[i] == true) || (digitalRead(toggIn2[i]) == HIGH && toggLog2[i] == true)){
      delay(50);
      Serial.print("t");
      Serial.print("#");
      Serial.print(i);
      Serial.print("#");
      Serial.println("0");
      toggLog1[i] = false;
      toggLog2[i] = false;        
    }
  }

    if((millis() - enc10bittoggleTime34) > enc10bittoggleDelay35){
  for(i = 0; i < 10; i++){  
    enc10bitBinaryPos4[i] = digitalRead(enc10bitPin4[i]);
  }
  #ifndef ENC10BIT_DEC4
    for(i = 0; i < 10; i++){
      if(enc10bitBinaryPos4[i] != enc10bitOldBinaryPos4[i]){
        enc10bitOldBinaryPos4[i] = enc10bitBinaryPos4[i];
        enc10bitPrint34 = true;
      }
    }
    
    for(i = 9; i > -1; i--){
      str10Bit34 += enc10bitBinaryPos4[i];
    }
  #else
    enc10bitPos345 = 0;
    k = 2;
    enc10bitPos345 += enc10bitBinaryPos4[0];
    for(i = 1; i < 10; i++){
      enc10bitPos345 += enc10bitBinaryPos4[i] * k;
      k *= 2; 
    }
    
    if(enc10bitPos345 != 0){
      enc10bitZero34 = 0;
    }
    else if(enc10bitPos345 == 0 && enc10bitZero34 != 2){
      enc10bitPos345 = enc10bitOldPos35;
      enc10bitZero34++;
    }
    else if(enc10bitPos345 == 0 && enc10bitZero34 == 2){
      enc10bitZero34 = 0;
    }
    if(enc10bitPos345 != enc10bitOldPos35){
      enc10bitOldPos35 = enc10bitPos345;
      enc10bitPrint34 = true;
    }
    //str = enc10bitPos345 - enc10bitLEFT34;
    str10Bit34 = String(enc10bitPos345);

    BitSTR35 = str10Bit34.toInt();
    BitSTR35new3 = BitSTR35 - enc10bitLEFT34;


      if (BitSTR35new3 < 0){
        BitSTR35new3 = 1024 + BitSTR35new3;
      }


if (!enc10bitMAP34){
    BitSTR35Print3 = BitSTR35new3;
    if (BitSTR35new3 < enc10bitdontNULL34) {
      BitSTR35Print3 = 0;
    }
     if (BitSTR35new3 > 1000){
      BitSTR35Print3 = 1000;
    }
    if (BitSTR35Print3ST3 != BitSTR35Print3){
     BitSTR35Print3ST3 = BitSTR35Print3;
     enc10bitPrint34New3 = true; 
      
      }
}else{
   BitSTR35Print3 = map(BitSTR35new3, 0, 1024, 0, 360); 
    if (enc10bitReversal354){
    BitSTR35Print3Rev3 = 360 - BitSTR35Print3;
    BitSTR35Print3 = BitSTR35Print3Rev3;
    Serial.println('-- '+BitSTR35Print3Rev3);
      }  
      if (BitSTR35Print3 < enc10bitdontNULL34map3) {
      BitSTR35Print3 = 0;
    }
     if (BitSTR35Print3 > 360 - enc10bitdontNULL34map3){
      BitSTR35Print3 = 0;
    }


    
      if (BitSTR35Print3ST3map3 != BitSTR35Print3){
     BitSTR35Print3ST3map3 = BitSTR35Print3;
     enc10bitPrint34New3 = true; 
      
      }
  
  }


   
  #endif
  if(print == true && enc10bitPrint34 == true && enc10bitPrint34New3 == true){
    Serial.print("p");
    Serial.print("#");
    Serial.print("3");
    Serial.print("#");
    Serial.println(BitSTR35Print3 / 100);
    //Serial.println(".00z");
  
    enc10bitPrint34 = false;
     enc10bitPrint34New3 = false; 
  }

enc10bittoggleTime34 = millis();
}


    if((millis() - enc10bittoggleTime3) > enc10bittoggleDelay3){
  for(i = 0; i < 10; i++){  
    enc10bitBinaryPos3[i] = digitalRead(enc10bitPin3[i]);
  }
  #ifndef ENC10BIT_DEC3
    for(i = 0; i < 10; i++){
      if(enc10bitBinaryPos3[i] != enc10bitOldBinaryPos3[i]){
        enc10bitOldBinaryPos3[i] = enc10bitBinaryPos3[i];
        enc10bitPrint3 = true;
      }
    }
    
    for(i = 9; i > -1; i--){
      str10Bit3 += enc10bitBinaryPos3[i];
    }
  #else
    enc10bitPos3 = 0;
    k = 2;
    enc10bitPos3 += enc10bitBinaryPos3[0];
    for(i = 1; i < 10; i++){
      enc10bitPos3 += enc10bitBinaryPos3[i] * k;
      k *= 2; 
    }
    
    if(enc10bitPos3 != 0){
      enc10bitZero3 = 0;
    }
    else if(enc10bitPos3 == 0 && enc10bitZero3 != 2){
      enc10bitPos3 = enc10bitOldPos3;
      enc10bitZero3++;
    }
    else if(enc10bitPos3 == 0 && enc10bitZero3 == 2){
      enc10bitZero3 = 0;
    }
    if(enc10bitPos3 != enc10bitOldPos3){
      enc10bitOldPos3 = enc10bitPos3;
      enc10bitPrint3 = true;
    }
    //str = enc10bitPos3 - enc10bitLEFT3;
    str10Bit3 = String(enc10bitPos3);

    BitSTR3 = str10Bit3.toInt();
    BitSTR3new3 = BitSTR3 - enc10bitLEFT3;


      if (BitSTR3new3 < 0){
        BitSTR3new3 = 1024 + BitSTR3new3;
      }


if (!enc10bitMAP3){
    BitSTR3Print3 = BitSTR3new3;
    if (BitSTR3new3 < enc10bitdontNULL3) {
      BitSTR3Print3 = 0;
    }
     if (BitSTR3new3 > 1000){
      BitSTR3Print3 = 1000;
    }
    if (BitSTR3Print3ST3 != BitSTR3Print3){
     BitSTR3Print3ST3 = BitSTR3Print3;
     enc10bitPrint3New3 = true; 
      
      }
}else{
   BitSTR3Print3 = map(BitSTR3new3, 0, 1024, 0, 360); 
    if (enc10bitReversal3){
    BitSTR3Print3Rev3 = 360 - BitSTR3Print3;
    BitSTR3Print3 = BitSTR3Print3Rev3;
    Serial.println('-- '+BitSTR3Print3Rev3);
      }  
      if (BitSTR3Print3 < enc10bitdontNULL3map3) {
      BitSTR3Print3 = 0;
    }
     if (BitSTR3Print3 > 360 - enc10bitdontNULL3map3){
      BitSTR3Print3 = 0;
    }


    
      if (BitSTR3Print3ST3map3 != BitSTR3Print3){
     BitSTR3Print3ST3map3 = BitSTR3Print3;
     enc10bitPrint3New3 = true; 
      
      }
  
  }


   
  #endif
  if(print == true && enc10bitPrint3 == true && enc10bitPrint3New3 == true){
    Serial.print("p");
    Serial.print("#");
    Serial.print("2");
    Serial.print("#");
    Serial.println(BitSTR3Print3 / 100);
    //Serial.println(".00z");
  
    enc10bitPrint3 = false;
     enc10bitPrint3New3 = false; 
  }

enc10bittoggleTime3 = millis();
}



    if((millis() - enc10bittoggleTime2) > enc10bittoggleDelay2){
  for(i = 0; i < 10; i++){  
    enc10bitBinaryPos2[i] = digitalRead(enc10bitPin2[i]);
  }
  #ifndef ENC10BIT_DEC2
    for(i = 0; i < 10; i++){
      if(enc10bitBinaryPos2[i] != enc10bitOldBinaryPos2[i]){
        enc10bitOldBinaryPos2[i] = enc10bitBinaryPos2[i];
        enc10bitPrint2 = true;
      }
    }
    
    for(i = 9; i > -1; i--){
      str10Bit2 += enc10bitBinaryPos2[i];
    }
  #else
    enc10bitPos2 = 0;
    k = 2;
    enc10bitPos2 += enc10bitBinaryPos2[0];
    for(i = 1; i < 10; i++){
      enc10bitPos2 += enc10bitBinaryPos2[i] * k;
      k *= 2; 
    }
    
    if(enc10bitPos2 != 0){
      enc10bitZero2 = 0;
    }
    else if(enc10bitPos2 == 0 && enc10bitZero2 != 2){
      enc10bitPos2 = enc10bitOldPos2;
      enc10bitZero2++;
    }
    else if(enc10bitPos2 == 0 && enc10bitZero2 == 2){
      enc10bitZero2 = 0;
    }
    if(enc10bitPos2 != enc10bitOldPos2){
      enc10bitOldPos2 = enc10bitPos2;
      enc10bitPrint2 = true;
    }
    //str = enc10bitPos2 - enc10bitLEFT2;
    str10Bit2 = String(enc10bitPos2);

    BitSTR2 = str10Bit2.toInt();
    BitSTR2new2 = BitSTR2 - enc10bitLEFT2;


      if (BitSTR2new2 < 0){
        BitSTR2new2 = 1024 + BitSTR2new2;
      }


if (!enc10bitMAP2){
    BitSTR2Print2 = BitSTR2new2;
    if (BitSTR2new2 < enc10bitdontNULL2) {
      BitSTR2Print2 = 0;
    }
     if (BitSTR2new2 > 1000){
      BitSTR2Print2 = 1000;
    }
    if (BitSTR2Print2ST2 != BitSTR2Print2){
     BitSTR2Print2ST2 = BitSTR2Print2;
     enc10bitPrint2New2 = true; 
      
      }
}else{
   BitSTR2Print2 = map(BitSTR2new2, 0, 1024, 0, 360); 
    if (enc10bitReversal2){
    BitSTR2Print2Rev2 = 360 - BitSTR2Print2;
    BitSTR2Print2 = BitSTR2Print2Rev2;
    Serial.println('-- '+BitSTR2Print2Rev2);
      }  
      if (BitSTR2Print2 < enc10bitdontNULL2map2) {
      BitSTR2Print2 = 0;
    }
     if (BitSTR2Print2 > 360 - enc10bitdontNULL2map2){
      BitSTR2Print2 = 0;
    }


    
      if (BitSTR2Print2ST2map2 != BitSTR2Print2){
     BitSTR2Print2ST2map2 = BitSTR2Print2;
     enc10bitPrint2New2 = true; 
      
      }
  
  }


   
  #endif
  if(print == true && enc10bitPrint2 == true && enc10bitPrint2New2 == true){
    Serial.print("p");
    Serial.print("#");
    Serial.print("1");
    Serial.print("#");
    Serial.println(BitSTR2Print2 / 100);
    //Serial.println(".00z");
  
    enc10bitPrint2 = false;
     enc10bitPrint2New2 = false; 
  }

enc10bittoggleTime2 = millis();
}
  // put your main code here, to run repeatedly:

  if((millis() - enc10bittoggleTime) > enc10bittoggleDelay){
  for(i = 0; i < 10; i++){  
    enc10bitBinaryPos[i] = digitalRead(enc10bitPin[i]);
  }
  #ifndef ENC10BIT_DEC
    for(i = 0; i < 10; i++){
      if(enc10bitBinaryPos[i] != enc10bitOldBinaryPos[i]){
        enc10bitOldBinaryPos[i] = enc10bitBinaryPos[i];
        enc10bitPrint = true;
      }
    }
    
    for(i = 9; i > -1; i--){
      str10Bit += enc10bitBinaryPos[i];
    }
  #else
    enc10bitPos = 0;
    k = 2;
    enc10bitPos += enc10bitBinaryPos[0];
    for(i = 1; i < 10; i++){
      enc10bitPos += enc10bitBinaryPos[i] * k;
      k *= 2; 
    }
    
    if(enc10bitPos != 0){
      enc10bitZero = 0;
    }
    else if(enc10bitPos == 0 && enc10bitZero != 2){
      enc10bitPos = enc10bitOldPos;
      enc10bitZero++;
    }
    else if(enc10bitPos == 0 && enc10bitZero == 2){
      enc10bitZero = 0;
    }
    if(enc10bitPos != enc10bitOldPos){
      enc10bitOldPos = enc10bitPos;
      enc10bitPrint = true;
    }
    //str = enc10bitPos - enc10bitLEFT;
    str10Bit = String(enc10bitPos);

    BitSTR = str10Bit.toInt();
    BitSTRnew = BitSTR - enc10bitLEFT;


      if (BitSTRnew < 0){
        BitSTRnew = 1024 + BitSTRnew;
      }


if (!enc10bitMAP){
    BitSTRPrint = BitSTRnew;
    if (BitSTRnew < enc10bitdontNULL) {
      BitSTRPrint = 0;
    }
     if (BitSTRnew > 1000){
      BitSTRPrint = 1000;
    }
    if (BitSTRPrintST != BitSTRPrint){
     BitSTRPrintST = BitSTRPrint;
     enc10bitPrintNew = true; 
      
      }
}else{
   BitSTRPrint = map(BitSTRnew, 0, 1024, 0, 360); 
    if (enc10bitReversal){
    BitSTRPrintRev = 360 - BitSTRPrint;
    BitSTRPrint = BitSTRPrintRev;
    Serial.println('-- '+BitSTRPrintRev);
      }  
      if (BitSTRPrint < enc10bitdontNULLmap) {
      BitSTRPrint = 0;
    }
     if (BitSTRPrint > 360 - enc10bitdontNULLmap){
      BitSTRPrint = 0;
    }


    
      if (BitSTRPrintSTmap != BitSTRPrint){
     BitSTRPrintSTmap = BitSTRPrint;
     enc10bitPrintNew = true; 
      
      }
  
  }


   
  #endif
  if(print == true && enc10bitPrint == true && enc10bitPrintNew == true){
    Serial.print("p");
    Serial.print("#");
    Serial.print("0");
    Serial.print("#");
    Serial.println(BitSTRPrint / 100);
    //Serial.println(".00z");
  
    enc10bitPrint = false;
     enc10bitPrintNew = false; 
  }

enc10bittoggleTime = millis();
}




//////////////РАБОТА РАЗЪЕМОВ 2///////////////////
  for (i = 0; i < razNUM; i++) { // Опрос РАЗЪЕМОВ 2

    traz = millis();


    if ((traz - razTime[i]) > razDELAY) {



      razPos[i] = analogRead(razPin[i]);
      if (abs(razPos[i] - oldrazPos[i]) > razERROR) {
        oldrazPos[i] = razPos[i];
        truerazPos[i] = razPos[i];
        if (truerazPos[i] > razBorder[i][1]) {
          truerazPos[i] = razBorder[i][1];
        }
        else if (truerazPos[i] < razBorder[i][0]) {
          truerazPos[i] = razBorder[i][0];
        }
        truerazPos[i] = (truerazPos[i] - razBorder[i][0]) / (razBorder[i][1] - razBorder[i][0]) * 1000;

        truerazPos[i] = (int)round(truerazPos[i]) / razERROR * razERROR;

        if (razType[i] == 0) {


          if (oldTruerazPos[i] != truerazPos[i]) {
            oldTruerazPos[i] = truerazPos[i];

            //if (razAnswer[i] == truerazPos[i]) {



#ifndef razSetup
            if (razAnswer[i] >= truerazPos[i] - razERRORAnswer && razAnswer[i] <= truerazPos[i] + razERRORAnswer)
            {

              truerazAnswer[i] = 1;
            } else {
              truerazAnswer[i] = 0;
            }
            if (truerazAnswer[i] != oldTruerazAnswer[i]) {
              Serial.print("c");
              Serial.print("#");
              Serial.print(i);
              Serial.print("#");


              if (truerazAnswer[i] == 1) {
                Serial.println("1");
              } else {
                Serial.println("0");
              }


              oldTruerazAnswer[i] = truerazAnswer[i];
              /*
                Serial.print("p");
                Serial.print(i);
                Serial.print(" ");
                Serial.print(truerazPos[i]);
                Serial.println("z");
              */
            }

#else


            Serial.print("c");
            Serial.print("#");
            Serial.print(i);
            Serial.print("#");
            Serial.println(truerazPos[i]);



#endif



          }
        }
      }
      razTime[i] = traz;
    }

  }



// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО ЭНКОДЕРОВ!
  rawPos[0] = enc0.rawPos(); // Опрос энкодера
   rawPos[1] = enc1.rawPos(); // Опрос энкодера
   
 
    

  #ifdef ENCSETUP
    for(i = 0; i < ENCNUM; i++){
      if (rawPos[i] != oldRawPos[i]){ // Вывод текущего положения энкодера при наличии изменений
        oldRawPos[i] = rawPos[i];     
        Serial.print("e");
        Serial.print(i);
        Serial.print(" ");
        Serial.println(rawPos[i]);
      }
    }
  #endif

  #ifndef ENCSETUP
    for(i = 0; i < ENCNUM; i++){ // Вывод в порт ПК текущего состояния энкодера
      if (rawPos[i] != oldRawPos[i]){
        oldRawPos[i] = rawPos[i];
        if(rawPos[i] == 255){
          #ifdef DEBUG
            Serial.print("e");
            Serial.print(i);
            Serial.print(" ");
            Serial.println("ERROR");
          #endif
        }
        else{
          if (rawBorder[i][0] < rawBorder[i][1]){
            if(encPoint[i] > 0){
              if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
                encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
              }
              else if((rawPos[i] < encPoint[i]) && (rawPos[i] >= rawBorder[i][1])){
                encPos[i] = 1.00;
              }
              else{
                encPos[i] = 0.00;
              }
            }
            else{
              if((rawPos[i] >= rawBorder[i][0]) && (rawPos[i] <= rawBorder[i][1])){
                encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
              }
              else if((rawPos[i] > -encPoint[i]) && (rawPos[i] <= rawBorder[i][0])){
                encPos[i] = 0.00;
              }
              else{
                encPos[i] = 1.00;
              }
            }
          }
          else{
            if(rawPos[i] >= rawBorder[i][0]){
              encPos[i] = (rawPos[i] - rawBorder[i][0]) / rawNorm[i];
            }
            else if(rawPos[i] <= rawBorder[i][1]){
              encPos[i] = (rawPos[i] + 128 - rawBorder[i][0]) / rawNorm[i];
            }
            else if(rawPos[i] < encPoint[i]){
              encPos[i] = 1.00;
            }
            else{
              encPos[i] = 0.00;
            }
          }
    
          if(encType[i] == 0){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
          }

          if(encType[i] == 1){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0]));
            if(encPos[i] == encBorder[i][1]){
              encPos[i] = encBorder[i][0];
            }
          }

          if(encType[i] == 2){
            encPos[i] = round(encPos[i] * (encBorder[i][1] - encBorder[i][0])) * 5.0;
            if(encPos[i] == encBorder[i][1]){
              encPos[i] = encBorder[i][0];
            }
          }

          if(encType[i] == 4){
            encPos[i] = round(encPos[i] * 100);
          }
          
          if(encPos[i] != oldEncPos[i]){
            oldEncPos[i] = encPos[i];
            Serial.print("e");
            Serial.print("#");
            Serial.print(i);
            Serial.print("#");
            Serial.println(encPos[i]);
          }
        }
      }
    }

  #endif



   for(i = 0; i < ELEM_NUM; i++){ // Опрос
    if(elemRev[i] == false){
      if((digitalRead(elemPin[i]) == HIGH) && (elemPos[i] == true)){
        if((millis() - elemTime[i]) > elemDelay[i]){
         
          Serial.print(elemSymbol);
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println("0");
          elemTime[i] = millis();
          elemPos[i] = false; 
        }
      }
      else if((digitalRead(elemPin[i]) == LOW) && (elemPos[i] == false)){
        if((millis() - elemTime[i]) > elemDelay[i]){
         
          Serial.print(elemSymbol);
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println("1");
          elemTime[i] = millis();
          elemPos[i] = true; 
        }      
      } 
    }
    else{
      if((digitalRead(elemPin[i]) == HIGH) && (elemPos[i] == false)){
        if((millis() - elemTime[i]) > elemDelay[i]){
          Serial.print(elemSymbol);
          Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println("1");
          elemTime[i] = millis();
          elemPos[i] = true; 
        }      
      }
      else if((digitalRead(elemPin[i]) == LOW) && (elemPos[i] == true)){
        if((millis() - elemTime[i]) > elemDelay[i]){
         Serial.print(elemSymbol);
         Serial.print("#");
          Serial.print(i);
          Serial.print("#");
          Serial.println("0");
          elemTime[i] = millis();
          elemPos[i] = false; 
        }  
      } 
    }
  }


  if (Serial.available() > 0){ // Проверка, что есть данные от ПК
    str = Serial.readStringUntil('\n');
   // Serial.println(str);

    if (str.substring(0, 2).equals("on")){ // Включить светодиод
      i = str.substring(3, 5).toInt();
      digitalWrite(diodIn[i], HIGH);
      diodLog[i] = true;
   /*   Serial.print("l");
      Serial.print(i);
      Serial.println(" on");*/
    }

    else if (str.substring(0, 3).equals("off")){ // Выключить светодиод
      i = str.substring(4, 6).toInt();
      digitalWrite(diodIn[i], LOW);
      diodLog[i] = false;
  /*    Serial.print("l");
      Serial.print(i);
      Serial.println(" off");*/
    }


      #ifdef STEPPER_SETUP
      if(str.substring(1, 2).equals("+") && stepperBuzy[i] == false){
      // Принудительная установка нуля
        stepperZeroSettingStepA[str.substring(0, 1).toInt()] = true;
      }
      else if(str.substring(1, 2).equals("*")){ // Принудительный абсолютный сдвиг стрелки
        stepper[str.substring(0, 1).toInt()].moveTo(str.substring(2, 13).toInt());
        #ifdef STEPPER_DEBUG
          Serial.println(digitalRead(stepperOptronPin[str.substring(0, 1).toInt()]));
        #endif
      }
      else if(str.substring(1, 2).equals("-")){ // Принудительный относительный сдвиг стрелки
        i = str.substring(0, 1).toInt();
        stepper[i].moveTo(str.substring(2, 13).toInt() + stepperZeroPos[i]);
      }
    #endif

    if (str.substring(0, 1).equals("s")) {

      ////                                                                      ////
      //        СВЯЗЬ ДЛЯ ДВИГАТЕЛЯ                                               //
      ////                                                                      ////

      #ifndef STEPPER_SETUP
        if(str.substring(1, 2).equals(stepperSymbol) && str.substring(4, 5).equals("+")){
        // Принудительная установка нуля
          stepperZeroSettingStepA[str.substring(2, 4).toInt()] = true;
        }
        else if(str.substring(0, 1).equals("s")){
        // Принудительный относительный сдвиг стрелки
          i = str.substring(1, 2).toInt();
          char myChar[11];
          str.substring(6, 10).toCharArray(myChar, 11);
          j2 = atol(myChar);
          if(j2 >= stepperBorder[i][0] && j2 <= stepperBorder[i][1]){
            stepperPos[i] = j2;
            stepperMoveStepA[i] = true;
            #ifdef STEPPER_DEBUG
              Serial.println(digitalRead(stepperOptronPin[i]));
            #endif
          }
        }
        else if(str.substring(1, 2).equals(stepperSymbolB)){
        // Принудительный относительный сдвиг стрелки
          i = str.substring(2, 4).toInt();
          if(i!=0){
            char myChar[11];
            str.substring(4, 15).toCharArray(myChar, 11);
            j2 = atol(myChar);
            /*
            if(j >= stepperBorder[i][0] && j <= stepperBorder[i][1]){
              stepperPos[i] += j;
              stepperMoveStepA[i] = true;
            }
            */
            if(j2 >= 0 && j2 <= 800){
              if(j2 == 800){
                j2 = 0;
              }
              long myI;
              myI = stepperPos[i] / 800;
              if(abs(j2 + 800 * myI - stepperPos[i]) < 400){
                stepperPos[i] = j2 + 800 * myI;
              }
              else if(abs(j2 + 800 * (myI + 1) - stepperPos[i]) < 400){
                stepperPos[i] = j2 + 800 * (myI + 1);
              }
              else if(abs(j2 + 800 * (myI - 1) - stepperPos[i]) < 400){
                stepperPos[i] = j2 + 800 * (myI - 1);
              }
              else if(abs(j2 + 800 * (myI + 2) - stepperPos[i]) < 400){
                stepperPos[i] = j2 + 800 * (myI + 2);
              }
              else if(abs(j2 + 800 * (myI - 2) - stepperPos[i]) < 400){
                stepperPos[i] = j2 + 800 * (myI - 2);
              }
              stepperMoveStepA[i] = true;
            }

          }
        }
      #endif

    }




    

}







   for(i = 0; i < STEPPER_NUM; i++){
    if(stepperZeroSettingLock[i] == false){
      stepper[i].run();
    }
    #ifdef STEPPER_DEBUG
      if(stepper[i].currentPosition() != stepperDebugPos[i]){
        stepperDebugPos[i] = stepper[i].currentPosition();
       Serial.println(stepperDebugPos[i]);
      }
    #endif
  }
}
