// Geometry.h: ������� ���� ��������� ��� DLL Geometry
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�������� stdafx.h �� ��������� ����� ����� � PCH"
#endif

#include "resource.h"		// �������� �������


// CGeometryApp
// ��� ���������� ������� ������ ��. Geometry.cpp
//

class CGeometryApp : public CWinApp
{
public:
	CGeometryApp();

// ���������������
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
