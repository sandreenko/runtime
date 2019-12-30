set COMPlus_JitFuncInfoLogFile=SIMD.log
set core_root=F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\Tests\Core_Root
set nofixup=1
set complus_JitDoSsa=0


pushd F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\JIT\SIMD\VectorAdd_r
call VectorAdd_r.cmd
popd

pushd F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\JIT\SIMD\AbsGeneric_r
call AbsGeneric_r.cmd
popd

pushd F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\JIT\SIMD\AbsGeneric_ro
call AbsGeneric_ro.cmd
popd 

pushd F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\JIT\SIMD\AbsSqrt_r
call AbsSqrt_r.cmd
popd

pushd F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\JIT\SIMD\AbsSqrt_ro
call AbsSqrt_ro.cmd
popd

pushd F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\JIT\SIMD\AddingSequence_r
call AddingSequence_r.cmd
popd

pushd F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\JIT\SIMD\AddingSequence_ro
call AddingSequence_ro.cmd
popd

pushd F:\git\runtime\artifacts\tests\coreclr\Windows_NT.x64.Checked\JIT\SIMD\BitwiseOperations_r
call BitwiseOperations_r.cmd
popd

