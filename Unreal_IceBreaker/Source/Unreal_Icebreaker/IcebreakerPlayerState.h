// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include <string>
#include "GameFramework/PlayerState.h"
#include "IcebreakerPlayerState.generated.h"

#define WatchEnumType ConstructorHelpers::FObjectFinder<UEnum> UEnum(TEXT("Enum 'Unsorted/E_WatchRecordings'"))

using namespace std;

/**
 * 
 */

struct AudioLog
{
	string logDescription;
	UAudioComponent logAudio;
};

enum EWatchRecordings
{
	UNDEFINED = 0,
	CH_Prologue_01 = 1,
	CH_Prologue_02 = 2,
	CH_Prologue_03 = 4,
	CH_One_01 = 8,
	CH_one_02 = 16
};

UCLASS()
class UNREAL_ICEBREAKER_API AIcebreakerPlayerState : public APlayerState
{
	
	GENERATED_BODY()
	
public:
	TMap<EWatchRecordings, AudioLog> AvailableAudioRecordings;
};
