; ModuleID = 'obj\Release\110\android\compressed_assemblies.armeabi-v7a.ll'
source_filename = "obj\Release\110\android\compressed_assemblies.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [15360 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_1 = internal global [166912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_2 = internal global [2217472 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_3 = internal global [121856 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_4 = internal global [684544 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_5 = internal global [171520 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_6 = internal global [92160 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_7 = internal global [5120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_8 = internal global [46080 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_9 = internal global [5120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_10 = internal global [35328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_11 = internal global [14752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_12 = internal global [389632 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_13 = internal global [747520 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_14 = internal global [26112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_15 = internal global [222720 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_16 = internal global [38912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_17 = internal global [7168 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_18 = internal global [419328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_19 = internal global [55808 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_20 = internal global [65024 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_21 = internal global [1397760 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_22 = internal global [876032 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_23 = internal global [98304 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_24 = internal global [14336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_25 = internal global [16384 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_26 = internal global [14848 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_27 = internal global [440320 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_28 = internal global [15872 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_29 = internal global [68608 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_30 = internal global [484864 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_31 = internal global [38912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_32 = internal global [146944 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_33 = internal global [14336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_34 = internal global [14336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_35 = internal global [14848 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_36 = internal global [8704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_37 = internal global [34304 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_38 = internal global [389120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_39 = internal global [12800 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_40 = internal global [25600 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_41 = internal global [52224 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_42 = internal global [30208 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_43 = internal global [1192448 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_44 = internal global [798720 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_45 = internal global [132608 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_46 = internal global [102400 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_47 = internal global [138240 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_48 = internal global [2120704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_49 = internal global [313344 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_50 = internal global [496128 x i8] zeroinitializer, align 1


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [51 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 15360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15360 x i8], [15360 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 166912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([166912 x i8], [166912 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 2217472, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2217472 x i8], [2217472 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 121856, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([121856 x i8], [121856 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 684544, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([684544 x i8], [684544 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 171520, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([171520 x i8], [171520 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 92160, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([92160 x i8], [92160 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([5120 x i8], [5120 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 46080, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([46080 x i8], [46080 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([5120 x i8], [5120 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 35328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([35328 x i8], [35328 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 14752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14752 x i8], [14752 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 389632, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([389632 x i8], [389632 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 747520, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([747520 x i8], [747520 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26112 x i8], [26112 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 222720, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([222720 x i8], [222720 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 38912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([38912 x i8], [38912 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([7168 x i8], [7168 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 419328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([419328 x i8], [419328 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 55808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([55808 x i8], [55808 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}, 
	; 20
	%struct.CompressedAssemblyDescriptor {
		i32 65024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([65024 x i8], [65024 x i8]* @__CompressedAssemblyDescriptor_data_20, i32 0, i32 0); data
	}, 
	; 21
	%struct.CompressedAssemblyDescriptor {
		i32 1397760, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1397760 x i8], [1397760 x i8]* @__CompressedAssemblyDescriptor_data_21, i32 0, i32 0); data
	}, 
	; 22
	%struct.CompressedAssemblyDescriptor {
		i32 876032, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([876032 x i8], [876032 x i8]* @__CompressedAssemblyDescriptor_data_22, i32 0, i32 0); data
	}, 
	; 23
	%struct.CompressedAssemblyDescriptor {
		i32 98304, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([98304 x i8], [98304 x i8]* @__CompressedAssemblyDescriptor_data_23, i32 0, i32 0); data
	}, 
	; 24
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_24, i32 0, i32 0); data
	}, 
	; 25
	%struct.CompressedAssemblyDescriptor {
		i32 16384, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16384 x i8], [16384 x i8]* @__CompressedAssemblyDescriptor_data_25, i32 0, i32 0); data
	}, 
	; 26
	%struct.CompressedAssemblyDescriptor {
		i32 14848, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14848 x i8], [14848 x i8]* @__CompressedAssemblyDescriptor_data_26, i32 0, i32 0); data
	}, 
	; 27
	%struct.CompressedAssemblyDescriptor {
		i32 440320, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([440320 x i8], [440320 x i8]* @__CompressedAssemblyDescriptor_data_27, i32 0, i32 0); data
	}, 
	; 28
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15872 x i8], [15872 x i8]* @__CompressedAssemblyDescriptor_data_28, i32 0, i32 0); data
	}, 
	; 29
	%struct.CompressedAssemblyDescriptor {
		i32 68608, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([68608 x i8], [68608 x i8]* @__CompressedAssemblyDescriptor_data_29, i32 0, i32 0); data
	}, 
	; 30
	%struct.CompressedAssemblyDescriptor {
		i32 484864, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([484864 x i8], [484864 x i8]* @__CompressedAssemblyDescriptor_data_30, i32 0, i32 0); data
	}, 
	; 31
	%struct.CompressedAssemblyDescriptor {
		i32 38912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([38912 x i8], [38912 x i8]* @__CompressedAssemblyDescriptor_data_31, i32 0, i32 0); data
	}, 
	; 32
	%struct.CompressedAssemblyDescriptor {
		i32 146944, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([146944 x i8], [146944 x i8]* @__CompressedAssemblyDescriptor_data_32, i32 0, i32 0); data
	}, 
	; 33
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_33, i32 0, i32 0); data
	}, 
	; 34
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_34, i32 0, i32 0); data
	}, 
	; 35
	%struct.CompressedAssemblyDescriptor {
		i32 14848, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14848 x i8], [14848 x i8]* @__CompressedAssemblyDescriptor_data_35, i32 0, i32 0); data
	}, 
	; 36
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8704 x i8], [8704 x i8]* @__CompressedAssemblyDescriptor_data_36, i32 0, i32 0); data
	}, 
	; 37
	%struct.CompressedAssemblyDescriptor {
		i32 34304, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([34304 x i8], [34304 x i8]* @__CompressedAssemblyDescriptor_data_37, i32 0, i32 0); data
	}, 
	; 38
	%struct.CompressedAssemblyDescriptor {
		i32 389120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([389120 x i8], [389120 x i8]* @__CompressedAssemblyDescriptor_data_38, i32 0, i32 0); data
	}, 
	; 39
	%struct.CompressedAssemblyDescriptor {
		i32 12800, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([12800 x i8], [12800 x i8]* @__CompressedAssemblyDescriptor_data_39, i32 0, i32 0); data
	}, 
	; 40
	%struct.CompressedAssemblyDescriptor {
		i32 25600, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([25600 x i8], [25600 x i8]* @__CompressedAssemblyDescriptor_data_40, i32 0, i32 0); data
	}, 
	; 41
	%struct.CompressedAssemblyDescriptor {
		i32 52224, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([52224 x i8], [52224 x i8]* @__CompressedAssemblyDescriptor_data_41, i32 0, i32 0); data
	}, 
	; 42
	%struct.CompressedAssemblyDescriptor {
		i32 30208, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30208 x i8], [30208 x i8]* @__CompressedAssemblyDescriptor_data_42, i32 0, i32 0); data
	}, 
	; 43
	%struct.CompressedAssemblyDescriptor {
		i32 1192448, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1192448 x i8], [1192448 x i8]* @__CompressedAssemblyDescriptor_data_43, i32 0, i32 0); data
	}, 
	; 44
	%struct.CompressedAssemblyDescriptor {
		i32 798720, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([798720 x i8], [798720 x i8]* @__CompressedAssemblyDescriptor_data_44, i32 0, i32 0); data
	}, 
	; 45
	%struct.CompressedAssemblyDescriptor {
		i32 132608, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([132608 x i8], [132608 x i8]* @__CompressedAssemblyDescriptor_data_45, i32 0, i32 0); data
	}, 
	; 46
	%struct.CompressedAssemblyDescriptor {
		i32 102400, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([102400 x i8], [102400 x i8]* @__CompressedAssemblyDescriptor_data_46, i32 0, i32 0); data
	}, 
	; 47
	%struct.CompressedAssemblyDescriptor {
		i32 138240, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([138240 x i8], [138240 x i8]* @__CompressedAssemblyDescriptor_data_47, i32 0, i32 0); data
	}, 
	; 48
	%struct.CompressedAssemblyDescriptor {
		i32 2120704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2120704 x i8], [2120704 x i8]* @__CompressedAssemblyDescriptor_data_48, i32 0, i32 0); data
	}, 
	; 49
	%struct.CompressedAssemblyDescriptor {
		i32 313344, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([313344 x i8], [313344 x i8]* @__CompressedAssemblyDescriptor_data_49, i32 0, i32 0); data
	}, 
	; 50
	%struct.CompressedAssemblyDescriptor {
		i32 496128, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([496128 x i8], [496128 x i8]* @__CompressedAssemblyDescriptor_data_50, i32 0, i32 0); data
	}
], align 4; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 51, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([51 x %struct.CompressedAssemblyDescriptor], [51 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 4


!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-4 @ 13ba222766e8e41d419327749426023194660864"}
