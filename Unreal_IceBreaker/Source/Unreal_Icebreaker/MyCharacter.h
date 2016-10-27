// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "GameFramework/Character.h"
#include "MyCharacter.generated.h"

UCLASS()
class UNREAL_ICEBREAKER_API AMyCharacter : public ACharacter
{
	GENERATED_BODY()
		
	float speedWalk;
	float speedRun;

	bool run = false;

public:
	// Sets default values for this character's properties
	AMyCharacter();

	void MoveForward(float AxisValue);

	void MoveRight(float AxisValue);

	void Turn(float AxisValue);

	void LookUp(float AxisValue);

	void Run();

	void Walk();

	// Called when the game starts or when spawned
	virtual void BeginPlay() override;
	
	// Called every frame
	virtual void Tick( float DeltaSeconds ) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* InputComponent) override;
	
};
