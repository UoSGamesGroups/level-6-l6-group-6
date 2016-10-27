// Fill out your copyright notice in the Description page of Project Settings.

#include "Unreal_Icebreaker.h"
#include "MyCharacter.h"


// Sets default values
AMyCharacter::AMyCharacter()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

void AMyCharacter::MoveForward(float AxisValue)
{
	if (run)
	{
		AddMovementInput(this->GetActorForwardVector(), AxisValue * speedRun);
	}
	else if (!run)
	{
		AddMovementInput(this->GetActorForwardVector(), AxisValue * speedWalk);
	}
}

void AMyCharacter::MoveRight(float AxisValue)
{
	if (run)
	{
		AddMovementInput(this->GetActorRightVector(), AxisValue * speedRun);
	}
	else if (!run)
	{
		AddMovementInput(this->GetActorRightVector(), AxisValue * speedWalk);
	}
}

void AMyCharacter::Turn(float AxisValue)
{
	this->AddControllerYawInput(AxisValue);
}

void AMyCharacter::LookUp(float AxisValue)
{
	this->AddControllerPitchInput(AxisValue);
}

void AMyCharacter::Run()
{
	run = true;
}

void AMyCharacter::Walk()
{
	run = false;
}

// Called when the game starts or when spawned
void AMyCharacter::BeginPlay()
{
	Super::BeginPlay();

	speedWalk = 1.0f;
	speedRun = 8.0f;

	run = false;
	
}

// Called every frame
void AMyCharacter::Tick( float DeltaTime )
{
	Super::Tick( DeltaTime );
	
}

// Called to bind functionality to input
void AMyCharacter::SetupPlayerInputComponent(class UInputComponent* InputComponent)
{
	Super::SetupPlayerInputComponent(InputComponent);

	InputComponent->BindAxis("MoveForward", this, &AMyCharacter::MoveForward);
	InputComponent->BindAxis("MoveRight", this, &AMyCharacter::MoveRight);
	InputComponent->BindAxis("Turn", this, &AMyCharacter::Turn);
	InputComponent->BindAxis("LookUp", this, &AMyCharacter::LookUp);

	InputComponent->BindAction("Run", IE_Pressed, this, &AMyCharacter::Run);
	InputComponent->BindAction("Run", IE_Released, this, &AMyCharacter::Walk);

}
