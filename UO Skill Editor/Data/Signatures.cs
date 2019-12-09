using System;

namespace Editor
{
	/// <summary>
	/// Contains skill signatures.
	/// </summary>
	public static class Signatures
	{
		#region Properties
		#region Skill Parameters Signature
		/// <summary>
		/// 7.0.10.3
		/// Address   Hex dump          Command                                  Comments
		/// 0049D533  |.  8935 5030A100 |MOV DWORD PTR DS:[0A13050],ESI
		/// 0049D539  |.  EB 1A         |JMP SHORT 0049D555
		/// 0049D53B  |>  8B35 5030A100 |MOV ESI,DWORD PTR DS:[0A13050]
		/// 0049D541  |.  8D14B6        |LEA EDX,[ESI*4+ESI]
		/// 0049D544  |.  C1E2 04       |SHL EDX,4
		/// 0049D547  |.  C686 442EA100 |MOV BYTE PTR DS:[ESI+0A12E44],0
		/// 0049D54E  |.  C682 A055A100 |MOV BYTE PTR DS:[EDX+0A155A0],0
		/// 0049D555  |>  83C5 01       |ADD EBP,1
		/// 0049D558  |.  83FD 3A       |CMP EBP,3A
		/// 0049D55B  |.^ 0F8C 72FFFFFF \JL 0049D4D3
		/// 0049D561  |.  6A 3A         PUSH 3A                                  ; /Arg3 = 3A
		/// 0049D563  |.  6A 00         PUSH 0                                   ; |Arg2 = 0
		/// 0049D565  |.  68 2431A100   PUSH OFFSET 00A13124                     ; |Arg1 = client_original.0A13124
		/// 0049D56A  |.  E8 51061600   CALL 005FDBC0                            ; \client_original.005FDBC0
		/// 0049D56F  |.  83C4 0C       ADD ESP,0C
		/// 0049D572  |.  33C0          XOR EAX,EAX
		/// 0049D574  |.  85F6          TEST ESI,ESI
		/// 0049D576  |.  7E 15         JLE SHORT 0049D58D
		/// 0049D578  |.  EB 06         JMP SHORT 0049D580
		/// 0049D57A  |   8D9B 00000000 LEA EBX,[EBX]
		/// 0049D580  |>  8880 2431A100 /MOV BYTE PTR DS:[EAX+0A13124],AL
		/// 0049D586  |.  83C0 01       |ADD EAX,1
		/// 0049D589  |.  3BC6          |CMP EAX,ESI
		/// 0049D58B  |.^ 7C F3         \JL SHORT 0049D580
		/// 0049D58D  |>  8D6E FF       LEA EBP,[ESI-1]
		/// 0049D590  |>  33FF          /XOR EDI,EDI
		/// </summary>
		private static byte[] _SkillParametersSignature = new byte[]
		{
			0x83, 0xC5, 0x01,
			0x83, 0xFD, 0xCC,
			0x0F, 0x8C, 0x72, 0xFF, 0xFF, 0xFF,
			0x6A, 0xCC,
			0x6A, 0x00,
			0x68, 0xCC, 0xCC, 0xCC, 0xCC
		};

		/// <summary>
		/// Skill parameters signature (static buffer address, skill count).
		/// </summary>
		public static byte[] SkillParametersSignature
		{
			get { return _SkillParametersSignature; }
		}

		/// <summary>
		/// Static buffer offset.
		/// </summary>
		public static int SkillBufferOffset
		{
			get { return 17; }
		}

		/// <summary>
		/// Skill count offset.
		/// </summary>
		public static int SkillCountOffset
		{
			get { return 5; }
		}
		#endregion

		#region Skill count signatures to replace
		/// <summary>
		/// 7.0.9.1 2D
		/// 3A0F8C72FFFFFF6A3A6A0068
		/// Address   Hex dump          Command                                  Comments
		/// 0049D4B0  /$  83EC 0C       SUB ESP,0C                               ; Skills
		/// 0049D4B3  |.  53            PUSH EBX
		/// 0049D4B4  |.  55            PUSH EBP
		/// 0049D4B5  |.  56            PUSH ESI
		/// 0049D4B6  |.  57            PUSH EDI
		/// 0049D4B7  |.  C705 5030A100 MOV DWORD PTR DS:[0A13050],0
		/// 0049D4C1  |.  33ED          XOR EBP,EBP
		/// 0049D4C3  |>  8D4424 18     /LEA EAX,[LOCAL.0]
		/// 0049D4C7  |.  50            |PUSH EAX                                ; /Arg5 => OFFSET LOCAL.0
		/// 0049D4C8  |.  8D4C24 18     |LEA ECX,[LOCAL.1]                       ; |
		/// 0049D4CC  |.  51            |PUSH ECX                                ; |Arg4 => OFFSET LOCAL.1
		/// 0049D4CD  |.  55            |PUSH EBP                                ; |Arg3
		/// 0049D4CE  |.  6A 10         |PUSH 10                                 ; |Arg2 = 10
		/// 0049D4D0  |.  6A 0F         |PUSH 0F                                 ; |Arg1 = 0F
		/// 0049D4D2  |.  E8 C9100C00   |CALL 0055E5A0                           ; \client.0055E5A0
		/// 0049D4D7  |.  83C4 14       |ADD ESP,14
		/// 0049D4DA  |.  85C0          |TEST EAX,EAX
		/// 0049D4DC  |.  74 4D         |JE SHORT 0049D52B
		/// 0049D4DE  |.  8A10          |MOV DL,BYTE PTR DS:[EAX]
		/// 0049D4E0  |.  8B7C24 14     |MOV EDI,DWORD PTR SS:[LOCAL.1]
		/// 0049D4E4  |.  8B0D 5030A100 |MOV ECX,DWORD PTR DS:[0A13050]
		/// 0049D4EA  |.  83C0 01       |ADD EAX,1
		/// 0049D4ED  |.  83C7 FF       |ADD EDI,-1
		/// 0049D4F0  |.  57            |PUSH EDI                                ; /Arg3
		/// 0049D4F1  |.  50            |PUSH EAX                                ; |Arg2
		/// 0049D4F2  |.  8D0489        |LEA EAX,[ECX*4+ECX]                     ; |
		/// 0049D4F5  |.  C1E0 04       |SHL EAX,4                               ; |
		/// 0049D4F8  |.  05 A055A100   |ADD EAX,OFFSET 00A155A0                 ; |
		/// 0049D4FD  |.  50            |PUSH EAX                                ; |Arg1
		/// 0049D4FE  |.  8891 442EA100 |MOV BYTE PTR DS:[ECX+0A12E44],DL        ; |
		/// 0049D504  |.  E8 67211600   |CALL 005FF670                           ; \client.005FF670
		/// 0049D509  |.  8B35 5030A100 |MOV ESI,DWORD PTR DS:[0A13050]
		/// 0049D50F  |.  8D0CB6        |LEA ECX,[ESI*4+ESI]
		/// 0049D512  |.  C1E1 04       |SHL ECX,4
		/// 0049D515  |.  83C4 0C       |ADD ESP,0C
		/// 0049D518  |.  83C6 01       |ADD ESI,1
		/// 0049D51B  |.  C68439 A055A1 |MOV BYTE PTR DS:[EDI+ECX+0A155A0],0
		/// 0049D523  |.  8935 5030A100 |MOV DWORD PTR DS:[0A13050],ESI
		/// 0049D529  |.  EB 1A         |JMP SHORT 0049D545
		/// 0049D52B  |>  8B35 5030A100 |MOV ESI,DWORD PTR DS:[0A13050]
		/// 0049D531  |.  8D14B6        |LEA EDX,[ESI*4+ESI]
		/// 0049D534  |.  C1E2 04       |SHL EDX,4
		/// 0049D537  |.  C686 442EA100 |MOV BYTE PTR DS:[ESI+0A12E44],0
		/// 0049D53E  |.  C682 A055A100 |MOV BYTE PTR DS:[EDX+0A155A0],0
		/// 0049D545  |>  83C5 01       |ADD EBP,1
		/// 0049D548  |.  83FD 3A       |CMP EBP,3A
		/// 0049D54B  |.^ 0F8C 72FFFFFF \JL 0049D4C3
		/// 0049D551  |.  6A 3A         PUSH 3A                                  ; /Arg3 = 3A
		/// 0049D553  |.  6A 00         PUSH 0                                   ; |Arg2 = 0
		/// 0049D555  |.  68 2431A100   PUSH OFFSET 00A13124                     ; |Arg1 = client.0A13124
		/// 0049D55A  |.  E8 91061600   CALL 005FDBF0                            ; \client.005FDBF0
		/// </summary>
		private static byte[] _Signature0 = new byte[]
		{
			0xCC,
			0x0F, 0x8C, 0x72, 0xFF, 0xFF, 0xFF,
			0x6A, 0xCC,
			0x6A, 0x00,
			0x68
		};

		/// <summary>
		/// Skill count signature.
		/// </summary>
		public static byte[] Signature0
		{
			get { return _Signature0; }
		}

		/// <summary>
		/// Skill count signature offset.
		/// </summary>
		public static int SignatureOffset0
		{
			get { return 8; }
		}


		/// <summary>
		/// 7.0.10.3 2D
		/// Address   Hex dump          Command                                  Comments
		/// 004687BE  |.  6A 64         PUSH 64                                  ; /Arg2 = 64
		/// 004687C0  |.  6A 64         PUSH 64                                  ; |Arg1 = 64
		/// 004687C2  |.  8BC8          MOV ECX,EAX                              ; |
		/// 004687C4  |.  E8 17350C00   CALL 0052BCE0                            ; \client_spyuo.0052BCE0
		/// 004687C9  |.  EB 02         JMP SHORT 004687CD
		/// 004687CB  |>  33C0          XOR EAX,EAX
		/// 004687CD  |>  6A 01         PUSH 1                                   ; /Arg2 = 1
		/// 004687CF  |.  57            PUSH EDI                                 ; |Arg1
		/// 004687D0  |.  8BC8          MOV ECX,EAX                              ; |
		/// 004687D2  |.  C74424 4C FFF MOV DWORD PTR SS:[LOCAL.0],-1            ; |
		/// 004687DA  |.  A3 90E59400   MOV DWORD PTR DS:[94E590],EAX            ; |
		/// 004687DF  |.  E8 2C210700   CALL 004DA910                            ; \client_spyuo.004DA910
		/// 004687E4  |>  57            PUSH EDI                                 ; /Arg1
		/// 004687E5  |.  E8 F6190C00   CALL 0052A1E0                            ; \client_spyuo.0052A1E0
		/// 004687EA  |.  83C4 04       ADD ESP,4
		/// 004687ED  |>  8A4424 14     MOV AL,BYTE PTR SS:[ESP+14]
		/// 004687F1  |.  33DB          XOR EBX,EBX
		/// 004687F3  |.  3C 01         CMP AL,1
		/// 004687F5  |.  74 4A         JE SHORT 00468841
		/// 004687F7  |.  3C 03         CMP AL,3
		/// 004687F9  |.  74 46         JE SHORT 00468841
		/// 004687FB  |.  84C0          TEST AL,AL
		/// 004687FD  |.  74 08         JE SHORT 00468807
		/// 004687FF  |.  3C 02         CMP AL,2
		/// 00468801  |.  0F85 A2000000 JNE 004688A9
		/// 00468807  |>  33C0          XOR EAX,EAX
		/// 00468809  |.  6A 3A         PUSH 3A                                  ; /Arg3 = 3A
		/// 0046880B  |.  50            PUSH EAX                                 ; |Arg2 => 0
		/// 0046880C  |.  B9 1D000000   MOV ECX,1D                               ; |
		/// 00468811  |.  BF 7035B300   MOV EDI,OFFSET 00B33570                  ; |
		/// 00468816  |.  68 3435B300   PUSH OFFSET 00B33534                     ; |Arg1 = client_spyuo.0B33534
		/// 0046881B  |.  F3:AB         REP STOS DWORD PTR ES:[EDI]              ; |
		/// 0046881D  |.  E8 9E531900   CALL 005FDBC0                            ; \client_spyuo.005FDBC0
		/// 00468822  |.  83C4 0C       ADD ESP,0C
		/// 00468825  |.  33C0          XOR EAX,EAX
		/// 00468827  |.  B9 1D000000   MOV ECX,1D
		/// 0046882C  |.  BF E835B300   MOV EDI,OFFSET 00B335E8
		/// 00468831  |.  F3:AB         REP STOS DWORD PTR ES:[EDI]
		/// 00468833  |.  B9 1D000000   MOV ECX,1D
		/// 00468838  |.  BF 6036B300   MOV EDI,OFFSET 00B33660
		/// </summary>
		private static byte[] _Signature1 = new byte[]
		{
			0x74, 0x46,
			0x84, 0xC0,
			0x74, 0x08,
			0x3C, 0x02,
			0x0F, 0x85, 0xA2, 0x00, 0x00, 0x00,
			0x33, 0xC0,
			0x6A, 0xCC,
			0x50
		};

		/// <summary>
		/// Skill count signature.
		/// </summary>
		public static byte[] Signature1
		{
			get { return _Signature1; }
		}

		/// <summary>
		/// Skill count signature offset.
		/// </summary>
		public static int SignatureOffset1
		{
			get { return 17; }
		}


		/// <summary>
		/// 7.0.10.3 2D
		/// Address   Hex dump          Command                                  Comments
		/// 0046885D  |. /74 0D         JE SHORT 0046886C
		/// 0046885F  |. |6A 64         PUSH 64                                  ; /Arg2 = 64
		/// 00468861  |. |6A 64         PUSH 64                                  ; |Arg1 = 64
		/// 00468863  |. |8BC8          MOV ECX,EAX                              ; |
		/// 00468865  |. |E8 76340C00   CALL 0052BCE0                            ; \client_spyuo.0052BCE0
		/// 0046886A  |. |8BF8          MOV EDI,EAX
		/// 0046886C  |> \56            PUSH ESI                                 ; /Arg2
		/// 0046886D  |.  6A 00         PUSH 0                                   ; |Arg1 = 0
		/// 0046886F  |.  8BCF          MOV ECX,EDI                              ; |
		/// 00468871  |.  C74424 4C FFF MOV DWORD PTR SS:[ESP+4C],-1             ; |
		/// 00468879  |.  8BDF          MOV EBX,EDI                              ; |
		/// 0046887B  |.  E8 90200700   CALL 004DA910                            ; \client_spyuo.004DA910
		/// 00468880  |.  89B7 BC000000 MOV DWORD PTR DS:[EDI+0BC],ESI
		/// 00468886  |.  33F6          XOR ESI,ESI
		/// 00468888  |>  6A 00         /PUSH 0                                  ; /Arg5 = 0
		/// 0046888A  |.  6A 00         |PUSH 0                                  ; |Arg4 = 0
		/// 0046888C  |.  6A 00         |PUSH 0                                  ; |Arg3 = 0
		/// 0046888E  |.  6A 00         |PUSH 0                                  ; |Arg2 = 0
		/// 00468890  |.  56            |PUSH ESI                                ; |Arg1
		/// 00468891  |.  8BCF          |MOV ECX,EDI                             ; |
		/// 00468893  |.  E8 68190C00   |CALL 0052A200                           ; \client_spyuo.0052A200
		/// 00468898  |.  83C6 01       |ADD ESI,1
		/// 0046889B  |.  83FE 3A       |CMP ESI,3A
		/// 0046889E  |.^ 7C E8         \JL SHORT 00468888
		/// 004688A0  |.  6A 01         PUSH 1                                   ; /Arg1 = 1
		/// 004688A2  |.  8BCF          MOV ECX,EDI                              ; |
		/// 004688A4  |.  E8 27190C00   CALL 0052A1D0                            ; \client_spyuo.0052A1D0
		/// </summary>
		private static byte[] _Signature2 = new byte[]
		{
			0x83, 0xC6, 0x01,
			0x83, 0xFE, 0xCC,
			0x7C, 0xE8,
			0x6A, 0x01,
			0x8B, 0xCF
		};

		/// <summary>
		/// Skill count signature.
		/// </summary>
		public static byte[] Signature2
		{
			get { return _Signature2; }
		}

		/// <summary>
		/// Skill count signature offset.
		/// </summary>
		public static int SignatureOffset2
		{
			get { return 5; }
		}

		/// <summary>
		/// 7.0.10.3 2D
		/// Address   Hex dump          Command                                  Comments
		/// 004689A3  |.  8B4C24 2C     |MOV ECX,DWORD PTR SS:[ESP+2C]           ; |
		/// 004689A7  |.  52            |PUSH EDX                                ; |Arg4
		/// 004689A8  |.  0FB65424 20   |MOVZX EDX,BYTE PTR SS:[ESP+20]          ; |
		/// 004689AD  |.  80EA 01       |SUB DL,1                                ; |
		/// 004689B0  |.  50            |PUSH EAX                                ; |Arg3 => 0
		/// 004689B1  |.  51            |PUSH ECX                                ; |Arg2
		/// 004689B2  |.  8B0D 90E59400 |MOV ECX,DWORD PTR DS:[94E590]           ; |
		/// 004689B8  |.  52            |PUSH EDX                                ; |Arg1
		/// 004689B9  |.  E8 42180C00   |CALL 0052A200                           ; \client_spyuo.0052A200
		/// 004689BE  |.  8A4424 14     |MOV AL,BYTE PTR SS:[ESP+14]
		/// 004689C2  |>  0FB74C24 18   |MOVZX ECX,WORD PTR SS:[ESP+18]
		/// 004689C7  |.  0FB75424 28   |MOVZX EDX,WORD PTR SS:[ESP+28]
		/// 004689CC  |.  66:89144D 5E3 |MOV WORD PTR DS:[ECX*2+0B3365E],DX
		/// 004689D4  |.  0FB75424 24   |MOVZX EDX,WORD PTR SS:[ESP+24]
		/// 004689D9  |.  66:89144D E63 |MOV WORD PTR DS:[ECX*2+0B335E6],DX
		/// 004689E1  |.  8A5424 15     |MOV DL,BYTE PTR SS:[ESP+15]
		/// 004689E5  |.  8891 3335B300 |MOV BYTE PTR DS:[ECX+0B33533],DL
		/// 004689EB  |.  0FB75424 20   |MOVZX EDX,WORD PTR SS:[ESP+20]
		/// 004689F0  |.  66:89144D 6E3 |MOV WORD PTR DS:[ECX*2+0B3356E],DX
		/// 004689F8  |>  83C6 01       |ADD ESI,1
		/// 004689FB  |.  83FE 3A       |CMP ESI,3A
		/// 004689FE  |.^ 0F8C A7FEFFFF \JL 004688AB
		/// 00468A04  |.  EB 04         JMP SHORT 00468A0A
		/// 00468A06  |>  8A4424 14     MOV AL,BYTE PTR SS:[ESP+14]
		/// 00468A0A  |>  8B0D 90E59400 MOV ECX,DWORD PTR DS:[94E590]
		/// 00468A10  |.  85C9          TEST ECX,ECX
		/// 00468A12  |.  74 0B         JE SHORT 00468A1F
		/// 00468A14  |.  6A FF         PUSH -1                                  ; /Arg1 = -1
		/// 00468A16  |.  E8 55200C00   CALL 0052AA70                            ; \client_spyuo.0052AA70
		/// </summary>
		private static byte[] _Signature3 = new byte[]
		{
			0x83, 0xC6, 0x01,
			0x83, 0xFE, 0xCC,
			0x0F, 0x8C, 0xA7, 0xFE, 0xFF, 0xFF,
			0xEB, 0x04,
			0x8A, 0x44, 0x24, 0x14
		};

		/// <summary>
		/// Skill count signature.
		/// </summary>
		public static byte[] Signature3
		{
			get { return _Signature3; }
		}

		/// <summary>
		/// Skill count signature offset.
		/// </summary>
		public static int SignatureOffset3
		{
			get { return 5; }
		}

		/// <summary>
		/// 7.0.10.3 2D
		/// Address   Hex dump          Command                                  Comments
		/// 0052A1FD      CC            INT3
		/// 0052A1FE      CC            INT3
		/// 0052A1FF      CC            INT3
		/// 0052A200  /$  8A4424 04     MOV AL,BYTE PTR SS:[ARG.1]               ; client_spyuo.0052A200(guessed Arg1,Arg2,Arg3,Arg4,Arg5)
		/// 0052A204  |.  3C 3A         CMP AL,3A
		/// 0052A206  |.  73 37         JNB SHORT 0052A23F
		/// 0052A208  |.  66:8B5424 08  MOV DX,WORD PTR SS:[ARG.2]
		/// 0052A20D  |.  0FB6C0        MOVZX EAX,AL
		/// 0052A210  |.  66:899441 5C0 MOV WORD PTR DS:[EAX*2+ECX+15C],DX
		/// 0052A218  |.  66:8B5424 0C  MOV DX,WORD PTR SS:[ARG.3]
		/// 0052A21D  |.  66:899441 D00 MOV WORD PTR DS:[EAX*2+ECX+1D0],DX
		/// 0052A225  |.  66:8B5424 10  MOV DX,WORD PTR SS:[ARG.4]
		/// 0052A22A  |.  66:899441 440 MOV WORD PTR DS:[EAX*2+ECX+244],DX
		/// 0052A232  |.  66:8B5424 14  MOV DX,WORD PTR SS:[ARG.5]
		/// 0052A237  |.  66:899441 B80 MOV WORD PTR DS:[EAX*2+ECX+2B8],DX
		/// 0052A23F  \>  C2 1400       RETN 14
		/// 0052A242      CC            INT3
		/// 0052A243      CC            INT3
		/// </summary>
		private static byte[] _Signature4 = new byte[]
		{
			0x8A, 0x44, 0x24, 0x04,
			0x3C, 0xCC,
			0x73, 0x37,
			0x66, 0x8B, 0x54, 0x24, 0x08
		};

		/// <summary>
		/// Skill count signature.
		/// </summary>
		public static byte[] Signature4
		{
			get { return _Signature4; }
		}

		/// <summary>
		/// Skill count signature offset.
		/// </summary>
		public static int SignatureOffset4
		{
			get { return 5; }
		}

		/// <summary>
		/// 7.0.10.3 2D
		/// Address   Hex dump                   Command                                  Comments
		/// 0052BCF1  |.  53                     PUSH EBX
		/// 0052BCF2  |.  55                     PUSH EBP
		/// 0052BCF3  |.  56                     PUSH ESI
		/// 0052BCF4  |.  57                     PUSH EDI
		/// 0052BCF5  |.  A1 D4987000            MOV EAX,DWORD PTR DS:[7098D4]
		/// 0052BCFA  |.  33C4                   XOR EAX,ESP
		/// 0052BCFC  |.  50                     PUSH EAX
		/// 0052BCFD  |.  8D4424 2C              LEA EAX,[LOCAL.2]
		/// 0052BD01  |.  64:A3 00000000         MOV DWORD PTR FS:[0],EAX
		/// 0052BD07  |.  8BE9                   MOV EBP,ECX
		/// 0052BD09  |.  896C24 24              MOV DWORD PTR SS:[LOCAL.4],EBP
		/// 0052BD0D  |.  E8 7EEFFAFF            CALL 004DAC90
		/// 0052BD12  |.  33DB                   XOR EBX,EBX
		/// 0052BD14  |.  895C24 34              MOV DWORD PTR SS:[LOCAL.0],EBX
		/// 0052BD18  |.  C745 00 94B46700       MOV DWORD PTR SS:[EBP],OFFSET 0067B494
		/// 0052BD1F  |.  E8 9C17F7FF            CALL 0049D4C0                            ; [client.0049D4C0
		/// 0052BD24  |.  8D85 D0010000          LEA EAX,[EBP+1D0]
		/// 0052BD2A  |.  8D4B 3A                LEA ECX,[EBX+3A]
		/// 0052BD2D  |.  8D49 00                LEA ECX,[ECX]
		/// 0052BD30  |>  66:8958 8C             /MOV WORD PTR DS:[EAX-74],BX
		/// 0052BD34  |.  66:8918                |MOV WORD PTR DS:[EAX],BX
		/// 0052BD37  |.  66:8958 74             |MOV WORD PTR DS:[EAX+74],BX
		/// 0052BD3B  |.  66:8998 E8000000       |MOV WORD PTR DS:[EAX+0E8],BX
		/// 0052BD42  |.  83C0 02                |ADD EAX,2
		/// 0052BD45  |.  83E9 01                |SUB ECX,1
		/// 0052BD48  |.^ 75 E6                  \JNE SHORT 0052BD30
		/// 0052BD4A  |.  889D 5A010000          MOV BYTE PTR SS:[EBP+15A],BL
		/// 0052BD50  |.  889D 58010000          MOV BYTE PTR SS:[EBP+158],BL
		/// 0052BD56  |.  889D 59010000          MOV BYTE PTR SS:[EBP+159],BL
		/// 0052BD5C  |.  C745 08 54B76700       MOV DWORD PTR SS:[EBP+8],OFFSET 0067B754 ; ASCII "skill gump"
		/// 0052BD63  |.  895D 78                MOV DWORD PTR SS:[EBP+78],EBX
		/// 0052BD66  |.  899D 4C010000          MOV DWORD PTR SS:[EBP+14C],EBX
		/// 0052BD6C  |.  899D 48010000          MOV DWORD PTR SS:[EBP+148],EBX
		/// 0052BD72  |.  899D 44010000          MOV DWORD PTR SS:[EBP+144],EBX
		/// 0052BD78  |.  899D 40010000          MOV DWORD PTR SS:[EBP+140],EBX
		/// 0052BD7E  |.  899D 54010000          MOV DWORD PTR SS:[EBP+154],EBX
		/// 0052BD84  |.  899D 50010000          MOV DWORD PTR SS:[EBP+150],EBX
		/// 0052BD8A  |.  391D 48E19400          CMP DWORD PTR DS:[94E148],EBX
		/// 0052BD90  |.  895C24 18              MOV DWORD PTR SS:[LOCAL.7],EBX
		/// 0052BD94  |.  895C24 20              MOV DWORD PTR SS:[LOCAL.5],EBX
		/// 0052BD98  |.  895C24 1C              MOV DWORD PTR SS:[LOCAL.6],EBX
		/// 0052BD9C  |.  0F84 C7000000          JE 0052BE69
		/// 0052BDA2  |.  8B15 40E19400          MOV EDX,DWORD PTR DS:[94E140]
		/// </summary>
		private static byte[] _Signature5 = new byte[]
		{
			0x8D, 0x85, 0xD0, 0x01, 0x00, 0x00,
			0x8D, 0x4B, 0xCC,
			0x8D, 0x49, 0x00,
			0x66, 0x89, 0x58 ,0x8C
		};

		/// <summary>
		/// Skill count signature.
		/// </summary>
		public static byte[] Signature5
		{
			get { return _Signature5; }
		}

		/// <summary>
		/// Skill count signature offset.
		/// </summary>
		public static int SignatureOffset5
		{
			get { return 8; }
		}
		#endregion
		#endregion
	}
}
