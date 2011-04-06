// Geometry.h: главный файл заголовка для DLL Geometry
//

#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h"		// основные символы


// CGeometryApp
// Про реализацию данного класса см. Geometry.cpp
//

class CGeometryApp : public CWinApp
{
public:
	CGeometryApp();

// Переопределение
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
