#pragma once

#include <cstdlib>

#define TEST_API __declspec(dllexport)

extern "C" TEST_API float FollowB(float _BY, float _EY, float _Sped);