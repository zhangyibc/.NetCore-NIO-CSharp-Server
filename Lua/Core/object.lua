function class(classname, super)  
     local cls = {}  
     if super then  
        cls = {}  
        for k,v in pairs(super) do cls[k] = v end  
        cls.super = super  
    else  
        cls = {ctor = function() end}  
    end  
  
    cls.__cname = classname  
    cls.__index = cls  
  
    function cls.new(...)  
        local instance = setmetatable({}, cls)  
        local create  
        create = function(c, ...)  
             if c.super then -- 递归向上调用create  
                  create(c.super, ...)  
             end  
             if c.ctor then  
                  c.ctor(instance, ...)  
             end  
        end  
        create(instance, ...)  
        instance.class = cls  
        return instance  
    end  
    return cls  
end